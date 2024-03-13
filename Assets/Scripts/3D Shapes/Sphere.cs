using UnityEngine;

[CreateAssetMenu]
public class Sphere : ScriptableObject
{
    public int Segments;
    public float Radius;
    public Vector3 TransformPosition;

    public Vector3[] Vertices
    {
        get
        {
            Vector3[] vertices = new Vector3[Segments * Segments];
            float angleIncrement = 360f / Segments;
            float verticalAngleIncrement = 180f / (Segments - 1);

            int vertexIndex = 0;

            for (int i = 0; i < Segments; i++)
            {
                for (int j = 0; j < Segments; j++)
                {
                    float x = TransformPosition.x + Radius
                        * Mathf.Sin(Mathf.Deg2Rad * i * angleIncrement)
                        * Mathf.Cos(Mathf.Deg2Rad * j * verticalAngleIncrement);

                    float z = TransformPosition.z + Radius
                        * Mathf.Sin(Mathf.Deg2Rad * i * angleIncrement)
                        * Mathf.Sin(Mathf.Deg2Rad * j * verticalAngleIncrement);

                    float y = TransformPosition.y + Radius
                        * Mathf.Cos(Mathf.Deg2Rad * i * angleIncrement);

                    vertices[vertexIndex++] = new Vector3(x, y, z);
                }
            }
            return vertices;
        }
    }
}
