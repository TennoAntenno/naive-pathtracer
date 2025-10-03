using System.Numerics;
using Raylib_cs;

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

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.SkyBlue);

            Raylib.BeginMode3D(camera);

            Raylib.DrawCube(new Vector3(-2, 1, 1), 1, 2, 1, Color.Red);
            Raylib.DrawSphere(new Vector3(1, 0.5f, 5), 1, Color.Blue);
            Raylib.DrawPlane(new Vector3(0, 0, 0), new Vector2(50, 50), Color.RayWhite);

            Raylib.EndMode3D();
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}