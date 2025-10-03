using Raylib_cs;

namespace naive_pathtracer;
public class Program
{
    public static void Main(string[] args)
    {
        Raylib.InitWindow(800, 450, "naive pathtracer");
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}