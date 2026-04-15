using OpenTK.Graphics.OpenGL4;

namespace Buffers
{
    public class VAO
    {
        public int vao = 0;

        public VAO()
        {
            vao = GL.GenVertexArray();
        }

        public void Bind() => GL.BindVertexArray(vao);
        public void Unbind() => GL.BindVertexArray(0);
        public void Delete() => GL.DeleteVertexArray(vao);
    }
}
