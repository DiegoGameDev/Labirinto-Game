using GameEngine.Object;
using OpenTK.Mathematics;

namespace GameEngine;

public class Camera : GameObject
{
    public static List<Camera> camerasInScene = new List<Camera>();

    Matrix4 model = Matrix4.Identity;
    Matrix4 view;
    Matrix4 projection;

    public Camera()
    {
        camerasInScene.Add(this);
    }
}
