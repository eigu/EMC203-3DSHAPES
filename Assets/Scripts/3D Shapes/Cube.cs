using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Cube : ScriptableObject
{
    public float Length;
    public float Height;
    public float Width;

    public Vector3 TransformPosition;
    public Vector3 TransformRotation;

    public Vector3[] FrontSide
    {
        get
        {
            return RotateSide(m_frontSide);
        }
    }

    public Vector3[] BackSide
    {
        get
        {
            return RotateSide(m_backSide);
        }
    }

    public Vector3[] LeftSide
    {
        get
        {
            return new Vector3[]
            {
                FrontSide[0], FrontSide[1], BackSide[1], BackSide[0]
            };
        }
    }

    public Vector3[] RightSide
    {
        get
        {
            return new Vector3[]
            {
                FrontSide[2], FrontSide[3], BackSide[3], BackSide[2]
            };
        }
    }

    private Vector3[] RotateSide(Vector3[] side)
    {
        var currentSide = new Vector3[side.Length];
        for (int i = 0; i < side.Length; i++)
        {
            var deductedVector = TransformPosition - side[i];
            var rotatedVector = RotateBy(TransformRotation.x, TransformRotation.y, TransformRotation.z, deductedVector.x, deductedVector.y, deductedVector.z);
            currentSide[i] = new Vector3(rotatedVector.x, rotatedVector.y, rotatedVector.z) + TransformPosition;
        }

        return currentSide;
    }

    private Vector3 RotateBy(float xAngle, float yAngle, float zAngle, float point1, float point2, float point3)
    {
        var cosX = Mathf.Cos(xAngle);
        var sinX = Mathf.Sin(xAngle);
        var cosY = Mathf.Cos(yAngle);
        var sinY = Mathf.Sin(yAngle);
        var cosZ = Mathf.Cos(zAngle);
        var sinZ = Mathf.Sin(zAngle);

        var a = point1 * (cosY * cosZ) + point2 * (-cosY * sinZ) + point3 * sinY;
        var b = point1 * (sinX * sinY * cosZ + cosX * sinZ) + point2 * (-sinX * sinY * sinZ + cosX * cosZ) + point3 * (-sinX * cosY);
        var c = point1 * (-cosX * sinY * cosZ + sinX * sinZ) + point2 * (cosX * sinY * sinZ + sinX * cosZ) + point3 * (cosX * cosY);

        return new Vector3(a, b, c);
    }

    private Vector3[] m_frontSide
    {
        get
        {
            return new Vector3[]
            {
                new Vector3(TransformPosition.x +(Width/2), TransformPosition.y +(Height/2), TransformPosition.z + (Length/2)),
                new Vector3(TransformPosition.x +(Width/2), TransformPosition.y -(Height/2), TransformPosition.z + (Length/2)),
                new Vector3(TransformPosition.x -(Width/2), TransformPosition.y -(Height/2), TransformPosition.z + (Length/2)),
                new Vector3(TransformPosition.x -(Width/2), TransformPosition.y +(Height/2), TransformPosition.z + (Length/2))
            };
        }
    }

    public Vector3[] m_backSide
    {
        get
        {
            return new Vector3[]
            {
                new Vector3(TransformPosition.x +(Width/2), TransformPosition.y +(Height/2), TransformPosition.z - (Length/2)),
                new Vector3(TransformPosition.x +(Width/2), TransformPosition.y -(Height/2), TransformPosition.z - (Length/2)),
                new Vector3(TransformPosition.x -(Width/2), TransformPosition.y -(Height/2), TransformPosition.z - (Length/2)),
                new Vector3(TransformPosition.x -(Width/2), TransformPosition.y +(Height/2), TransformPosition.z - (Length/2))
            };
        }
    }
}
