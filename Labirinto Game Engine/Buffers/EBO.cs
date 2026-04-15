using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Buffers;

public class EBO
{
    int ebo = 0;

    public EBO(uint[] data)
    {
        ebo = GL.GenBuffer();
        Bind();
        GL.BufferData(BufferTarget.ElementArrayBuffer, data.Length * sizeof(uint), data, BufferUsageHint.StaticDraw);
    }

    public void Bind() => GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
    public void Unbind() => GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
    public void Delete() => GL.DeleteBuffer(ebo);
}