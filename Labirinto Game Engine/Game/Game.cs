using GameEngine.Shaders;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace GameEngine
{
    public class Game : GameWindow
    {
        public static Vector2i WindowSize { get; private set; }

        public Game(int w, int h, string name) : base(new GameWindowSettings(), NativeWindowSettings.Default)
        {
            Size = (w, h);
            Title = name;
            WindowSize = Size;
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

        float velocity = 10f;

        protected override void OnLoad()
        {
            GL.ClearColor(Color4.Black);

            world = new World(WorldDataGenerator.ReadData("InsertYourpath"));

            shaderDefaut = new Shader(@"C:\Users\DiegoMogger\source\repos\Labirinto Game Engine\Labirinto Game Engine\Game\Shaders\ShaderObjects\Default.vert"
                , @"C:\Users\DiegoMogger\source\repos\Labirinto Game Engine\Labirinto Game Engine\Game\Shaders\ShaderObjects\Default.frag");

            shaderDefaut.Use();
            shaderDefaut.Mat4(Matrix4.Identity, "model");
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
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color4.Aqua);
            GL.Enable(EnableCap.DepthTest);
            GL.Disable(EnableCap.CullFace);


            camera.SetViewAndProjection(shaderDefaut);
            world.Render(shaderDefaut);

            SwapBuffers();
            Title = camera.transform.Position.ToString();
        }

        protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
        {
            base.OnFramebufferResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
            WindowSize = Size;
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            var input = KeyboardState;

            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.W))
                camera.transform.Position += new Vector3(0, 0, -velocity * (float)args.Time);
            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.S))
                camera.transform.Position += new Vector3(0, 0, velocity * (float)args.Time);
            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.A))
                camera.transform.Position += new Vector3(-velocity * (float)args.Time, 0, 0);
            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.D))
                camera.transform.Position += new Vector3(velocity * (float)args.Time, 0, 0);

            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.LeftShift))
                camera.transform.Position += new Vector3(0, -velocity * (float)args.Time, 0);
            if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Space))
                camera.transform.Position += new Vector3(0, velocity * (float)args.Time, 0);

        }
    }
}
