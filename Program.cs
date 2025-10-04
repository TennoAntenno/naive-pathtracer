using System.Numerics;
using Raylib_cs;
using Scene;

namespace naive_pathtracer;

public class Program
{
    public static void Main(string[] args)
    {
        Raylib.InitWindow(800, 450, "naive pathtracer");
        Raylib.SetTargetFPS(60);

        Camera3D camera = new Camera3D();
        camera.FovY = 60;
        camera.Position = new Vector3(5, 7.5f, 10);
        camera.Up = new Vector3(0, 1, 0);
        camera.Target = new Vector3(0, 0, 0);
        camera.Projection = CameraProjection.Perspective;

        SceneObject[] objects = [
            new SceneObject {
                Type = ShapeType.Cube,
                Position = new Vector3(-2, 1, 1),
                Size = new Vector3(1, 2, 1),
                Color = Color.Red
            },
            new SceneObject {
                Type = ShapeType.Sphere,
                Position = new Vector3(1, 0.5f, 5),
                Radius = 1f,
                Color = Color.Blue
            },
            new SceneObject {
                Type = ShapeType.Plane,
                Position = new Vector3(0, 0, 0),
                PlaneSize = new Vector2(50, 50),
                Color = Color.RayWhite
            }
        ];

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.SkyBlue);

            Raylib.BeginMode3D(camera);

            foreach (var obj in objects)
            {
                obj.Draw();
            }

            Raylib.EndMode3D();

            Raylib.DrawFPS(25, 25);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
