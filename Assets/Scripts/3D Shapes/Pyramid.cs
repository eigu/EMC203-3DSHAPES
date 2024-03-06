using UnityEngine;

[CreateAssetMenu]
public class Pyramid : ScriptableObject
{
    public float Length;
    public float Height;
    public float Width;

    public Vector3 TransformPosition;

    public Vector3[] FrontSide
    {
        get
        {
            return new Vector3[]
            {
                new Vector3(TransformPosition.x + (Width/2),
                TransformPosition.y - (Height/2),
                TransformPosition.z + (Length/2)),

                new Vector3(TransformPosition.x,
                TransformPosition.y + (Height/2),
                TransformPosition.z),

                new Vector3(TransformPosition.x - (Width/2),
                TransformPosition.y - (Height/2),
                TransformPosition.z + (Length/2)),
            };
        }
    }

    public Vector3[] BackSide
    {
        get
        {
            return new Vector3[]
            {
                new Vector3(TransformPosition.x + (Width/2),
                TransformPosition.y - (Height/2),
                TransformPosition.z - (Length/2)),

                new Vector3(TransformPosition.x,
                TransformPosition.y + (Height/2),
                TransformPosition.z),

                new Vector3(TransformPosition.x - (Width/2),
                TransformPosition.y - (Height/2),
                TransformPosition.z - (Length/2)),
            };
        }
    }

    public Vector3[] LeftSide
    {
        get
        {
            return new Vector3[]
            {
                FrontSide[0], FrontSide[1], BackSide[0]
            };
        }
    }

    public Vector3[] RightSide
    {
        get
        {
            return new Vector3[]
            {
                FrontSide[2], FrontSide[1], BackSide[2]
            };
        }
    }
}
