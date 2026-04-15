using GameEngine;
using OpenTK.Graphics.OpenGL4;


public class Program
{
    public static void Main(string[] args)
    {
        using (Game game = new Game(500, 500, "Labirinto Game Engine"))
        {
            game.Run();
        }
    }
}