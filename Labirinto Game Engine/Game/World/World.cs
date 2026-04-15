using Buffers;
using GameEngine.Shaders;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace GameEngine
{
    public class World
    {
        private Block[,] chunk = new Block[1, 1];
        private Vector2i Size = Vector2i.Zero;

        List<Vector2> vertices = new List<Vector2>();
        List<uint> indices = new List<uint>();

        uint[] indicesStart =
        {
            1, 0, 2,
            0, 3, 2,
        };

        VAO vAO;
        VBO vBO;
        EBO eBO;

        public World(int Width, int Height)
        {
            Size.X = Width;
            Size.Y = Height;
            chunk = new Block[Size.X, Size.Y];

            ConstructWorld();
        }

        public World(Vector2 size)
        {
            Size = (Vector2i)size;
            chunk = new Block[Size.X, Size.Y];
            ConstructWorld();
        }

        private void ConstructWorld()
        {
            for (int x = 0; x < Size.X; x++)
            {
                for (int y = 0; y < Size.Y; y++)
                {
                    chunk[x, y] = new Block(new Vector2(x, y));
                    vertices.AddRange(chunk[x, y].vertices);

                    indicesStart[0] += (uint)vertices.Count;
                    indicesStart[1] += (uint)vertices.Count;
                    indicesStart[2] += (uint)vertices.Count;
                    indicesStart[3] += (uint)vertices.Count;
                    indicesStart[4] += (uint)vertices.Count;
                    indicesStart[5] += (uint)vertices.Count;
                    indices.AddRange(indicesStart);
                    
                }
            }

            vAO = new VAO();
            vAO.Bind();
            vBO = new VBO(vertices.ToArray(), 0);
            vAO.Bind();
            eBO = new EBO(indices.ToArray());
        }

        public void Render(Shader shader)
        {
            shader.Use();
            GL.BindVertexArray(vAO.vao);

            GL.DrawElements(BeginMode.Triangles, indices.Count, DrawElementsType.UnsignedInt, 0);
        }
    }
}
