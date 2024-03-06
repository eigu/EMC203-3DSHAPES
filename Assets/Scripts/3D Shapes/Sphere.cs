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

            int vertIndex = 0;

            for (int i = 0; i < Segments; i++)
            {
                for (int j = 0; j < Segments; j++)
                {
                    float theta = Mathf.PI * (i + 1) / (Segments + 1);
                    float phi = 2 * Mathf.PI * j / Segments;

                    float x = TransformPosition.x + Radius * Mathf.Sin(theta) * Mathf.Cos(phi);
                    float y = TransformPosition.y + Radius * Mathf.Cos(theta);
                    float z = TransformPosition.z + Radius * Mathf.Sin(theta) * Mathf.Sin(phi);

                    vertices[vertIndex++] = new Vector3(x, y, z);
                }
            }

            return vertices;
        }
    }
}
