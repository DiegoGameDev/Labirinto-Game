using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace GameEngine.Shaders
{
    public class Shader
    {
        private int Handle = 0;

        public Shader(string vert, string frag)
        {
            vert = File.ReadAllText(vert);
            frag = File.ReadAllText(frag);

            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            int fragShader = GL.CreateShader(ShaderType.FragmentShader);

            GL.ShaderSource(vertexShader, vert);
            GL.ShaderSource(fragShader, frag);

            GL.CompileShader(vertexShader);
            GL.CompileShader(fragShader);

            Handle = GL.CreateProgram();
            GL.AttachShader(Handle, vertexShader);
            GL.AttachShader(Handle, fragShader);
            GL.LinkProgram(Handle);

            GL.DetachShader(Handle, vertexShader);
            GL.DetachShader(Handle, fragShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragShader);

            GL.UseProgram(Handle);
        }

        public void Use() => GL.UseProgram(Handle);

        public void Uniform1(double value, string name) => GL.Uniform1(GL.GetUniformLocation(Handle, name), value);
        public void Uniform2(Vector2 value, string name) => GL.Uniform2(GL.GetUniformLocation(Handle, name), value);
        public void Uniform3(Vector3 value, string name) => GL.Uniform3(GL.GetUniformLocation(Handle, name), value);
        public void Uniform4(Vector4 value, string name) => GL.Uniform4(GL.GetUniformLocation(Handle, name), value);

        public void Mat4(Matrix4 value, string name) => GL.UniformMatrix4(GL.GetUniformLocation(Handle, name), false, ref value);
    }
}
