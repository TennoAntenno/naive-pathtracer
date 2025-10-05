using System.Numerics;
using Raylib_cs;
using Scene;

namespace RayHandling;

public struct RaySceneCollision
{
    public bool Hit;
    public float Distance;
    public Vector3 Point;
    public Vector3 Normal;

    public static RayCollision GetCollision(Ray ray, SceneObject obj)
    {
        switch (obj.Type)
        {
            case ShapeType.Cube:
                BoundingBox bounds = new BoundingBox(
                    obj.Position - obj.Size / 2,
                    obj.Position + obj.Size / 2
                );
                return Raylib.GetRayCollisionBox(ray, bounds);

            case ShapeType.Sphere:
                return Raylib.GetRayCollisionSphere(ray, obj.Position, obj.Radius);

            case ShapeType.Plane:
                Vector3 p1 = obj.Position + new Vector3(-obj.PlaneSize.X / 2, 0, -obj.PlaneSize.Y / 2);
                Vector3 p2 = obj.Position + new Vector3(obj.PlaneSize.X / 2, 0, -obj.PlaneSize.Y / 2);
                Vector3 p3 = obj.Position + new Vector3(obj.PlaneSize.X / 2, 0, obj.PlaneSize.Y / 2);
                Vector3 p4 = obj.Position + new Vector3(-obj.PlaneSize.X / 2, 0, obj.PlaneSize.Y / 2);

                RayCollision c1 = Raylib.GetRayCollisionTriangle(ray, p1, p2, p3);
                RayCollision c2 = Raylib.GetRayCollisionTriangle(ray, p1, p3, p4);
                return (c1.Hit && (!c2.Hit || c1.Distance < c2.Distance)) ? c1 : c2;

            default:
                return new RayCollision();
        }
    }
}
