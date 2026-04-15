using GameEngine.Shaders;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace GameEngine
{
    public class Game : GameWindow
    {
        public Game(int w, int h, string name) : base(new GameWindowSettings(), NativeWindowSettings.Default)
        {
            Size = (w, h);
            Title = name;
        }

        Shader shaderDefaut = default;
        World world;

        Camera camera;

        Vector3[] vertices =
        {
            new Vector3(-0.5f, -0.5f ,0),
            new Vector3(0.5f, -0.5f ,0),
            new Vector3(0f, 0.5f ,0),
        };

        protected override void OnLoad()
        {
            GL.ClearColor(Color4.Black);

            world = new World(20, 5);

            shaderDefaut = new Shader(@"C:\Users\DiegoMogger\source\repos\Labirinto Game Engine\Labirinto Game Engine\Game\Shaders\ShaderObjects\Default.vert"
                , @"C:\Users\DiegoMogger\source\repos\Labirinto Game Engine\Labirinto Game Engine\Game\Shaders\ShaderObjects\Default.frag");

            shaderDefaut.Use();
            camera = new Camera();

            base.OnLoad();
        }

        protected override void OnUnload()
        {
            base.OnUnload();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color4.Black);

            world.Render(shaderDefaut);

            SwapBuffers();
        }

        protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
        {
            base.OnFramebufferResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
        }
    }
}
