using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Buffers;

public class VBO
{
    int vbo = 0;

    public VBO(Vector2[] data, int index)
    {
        vbo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
        GL.BufferData(BufferTarget.ArrayBuffer, data.Length * Vector2.SizeInBytes, data, BufferUsageHint.StaticDraw);
        GL.VertexAttribPointer(index, 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0);
        GL.EnableVertexAttribArray(index);
    }

    public void Bind() => GL.BindBuffer(BufferTarget.ArrayBuffer,vbo);
    public void Unbind() => GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
    public void Delete() => GL.DeleteBuffer(vbo);
}

