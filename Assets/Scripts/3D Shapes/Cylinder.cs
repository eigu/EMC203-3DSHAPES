using UnityEngine;

[CreateAssetMenu]
public class Cylinder : ScriptableObject
{
    public int Segments;
    public float Height;

    public Vector3 TransformPosition;

    public Vector3[] TopSide
    {
        get
        {
            Vector3[] frontVertices = new Vector3[Segments];

            float angleIncrement = 360f / Segments;

            for (int i = 0; i < Segments; i++)
            {
                float x = TransformPosition.x + Mathf.Cos(Mathf.Deg2Rad * i * angleIncrement);
                float z = TransformPosition.z + Mathf.Sin(Mathf.Deg2Rad * i * angleIncrement);

                frontVertices[i] = new Vector3(x, TransformPosition.y + Height / 2, z);
            }

            return frontVertices;
        }
    }

    public Vector3[] BottomSide
    {
        get
        {
            Vector3[] backVertices = new Vector3[Segments];

            float angleIncrement = 360f / Segments;

            for (int i = 0; i < Segments; i++)
            {
                float x = TransformPosition.x + Mathf.Cos(Mathf.Deg2Rad * i * angleIncrement);
                float z = TransformPosition.z + Mathf.Sin(Mathf.Deg2Rad * i * angleIncrement);

                backVertices[i] = new Vector3(x, TransformPosition.y - Height / 2, z);
            }

            return backVertices;
        }
    }

    public Vector3[] Sides
    {
        get
        {
            Vector3[] sideVertices = new Vector3[Segments * 2];

            float angleIncrement = 360f / Segments;

            for (int i = 0; i < Segments; i++)
            {
                sideVertices[i * 2] = TopSide[i];
                sideVertices[i * 2 + 1] = BottomSide[i];
            }

            return sideVertices;
        }
    }
}
