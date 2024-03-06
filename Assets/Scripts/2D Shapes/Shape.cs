using UnityEngine;

[CreateAssetMenu]
public class Shape : ScriptableObject
{
    [SerializeField] private Vector3[] _points;

    public Vector3 TransformPosition;

    public Vector3[] ActualPoints
    {
        get
        {
            var newPoint = new Vector3[_points.Length];

            for( int i = 0; i < newPoint.Length; i++)
            {
                newPoint[i] = TransformPosition - _points[i];
            }

            return newPoint;
        }
    }
}
