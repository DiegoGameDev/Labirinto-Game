using GameEngine.Object;
using GameEngine.Shaders;
using OpenTK.Mathematics;

namespace GameEngine;

public class Camera : GameObject
{
    public static List<Camera> camerasInScene = new List<Camera>();

    Vector3 up = Vector3.UnitY;

    public Camera()
    {
        camerasInScene.Add(this);
        transform.Position = new Vector3(0, 0, 3f);
    }

    public void SetViewAndProjection(Shader shader)
    {
        shader.Use();
        Matrix4 view = Matrix4.LookAt(transform.Position, transform.Position + new Vector3(0,0, -1), up);
        Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45), (float)Game.WindowSize.X / (float)Game.WindowSize.Y, 0.1f, 100f);

        //shader.Mat4(Matrix4.Identity, "model");
        shader.Mat4(view, "view");
        shader.Mat4(projection, "projection");
    }
}
