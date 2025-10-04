using Raylib_cs;
using System.Numerics;

namespace Scene;

public enum ShapeType
{
    Cube,
    Sphere,
    Plane,
    Mesh
}

public struct SceneObject {
    public ShapeType Type;
    public Vector3 Position;
    public Vector3 Size; // cubes
    public float Radius; // spheres
    public Vector2 PlaneSize; // planes

    public Color Color;

    public void Draw() {
        switch (Type) {
            case ShapeType.Cube:
                Raylib.DrawCube(Position, Size.X, Size.Y, Size.Z, Color);
                break;
            case ShapeType.Sphere:
                Raylib.DrawSphere(Position, Radius, Color);
                break;
            case ShapeType.Plane:
                Raylib.DrawPlane(Position, PlaneSize, Color);
                break;
        }
    }
}
