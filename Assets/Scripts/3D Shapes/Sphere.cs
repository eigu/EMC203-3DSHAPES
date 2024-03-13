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
            int vertexCount = (Segments + 1) * (Segments + 1);
            Vector3[] vertices = new Vector3[vertexCount];

            for (int i = 0; i <= Segments; i++)
            {
                for (int j = 0; j <= Segments; j++)
                {
                    float u = (float)i / Segments;
                    float v = (float)j / Segments;

                    float theta = u * 2 * Mathf.PI;
                    float phi = v * Mathf.PI;

                    float x = Mathf.Sin(phi) * Mathf.Cos(theta);
                    float y = Mathf.Cos(phi);
                    float z = Mathf.Sin(phi) * Mathf.Sin(theta);

                    vertices[i * (Segments + 1) + j] = new Vector3(x, y, z) * Radius + TransformPosition;
                }
            }

            return vertices;
        }
    }
}
