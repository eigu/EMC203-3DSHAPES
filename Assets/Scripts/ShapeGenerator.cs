using UnityEngine;

public class ShapeGenerator : MonoBehaviour
{
    [SerializeField] private float _focalLength;

    [SerializeField] private Material _lineMaterial;

    [Header("2D Shapes")]
    [SerializeField] private Shape _drawShape;

    [Header("3D Shapes")]
    [SerializeField] private Cube _drawCube;
    [SerializeField] private Pyramid _drawPyramid;
    [SerializeField] private Cylinder _drawCylinder;
    [SerializeField] private Sphere _drawSphere;

    private void OnPostRender()
    {
        GL.PushMatrix();
        GL.Begin(GL.LINES);
        _lineMaterial.SetPass(0);

        GL.Color(_lineMaterial.color);

        DrawShapes();
        
        GL.End();
        GL.PopMatrix();
    }

    private void DrawShapes()
    {
        #region Shape
        DrawLine(_drawShape.ActualPoints);
        #endregion

        #region Cube
        DrawLine(_drawCube.FrontSide);
        DrawLine(_drawCube.BackSide);
        DrawLine(_drawCube.LeftSide);
        DrawLine(_drawCube.RightSide);
        #endregion

        #region Pyramid
        DrawLine(_drawPyramid.FrontSide);
        DrawLine(_drawPyramid.BackSide);
        DrawLine(_drawPyramid.LeftSide);
        DrawLine(_drawPyramid.RightSide);
        #endregion

        #region Cylinder
        DrawLine(_drawCylinder.TopSide);
        DrawLine(_drawCylinder.BottomSide);
        DrawLine(_drawCylinder.Sides);
        #endregion

        #region Sphere
        DrawLine(_drawSphere.Vertices);
        #endregion
    }

    private void DrawLine(Vector3[] vector3s)
    {
        var points = vector3s;

        for (int i = points.Length - 1; i >= 0; i--)
        {
            var nextShape = (i + 1) % points.Length;

            var point1 = new Vector3(points[i].x, points[i].y, 0)
                * (_focalLength / (points[i].z + _focalLength));

            GL.Vertex3(point1.x, point1.y, 0);

            var point2 = new Vector3(points[nextShape].x, points[nextShape].y, 0)
                * (_focalLength / (points[nextShape].z + _focalLength));

            GL.Vertex3(point2.x, point2.y, 0);
        }
    }
}
