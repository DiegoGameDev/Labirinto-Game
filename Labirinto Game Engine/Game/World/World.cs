using Buffers;
using GameEngine.Shaders;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace GameEngine
{
    public class World
    {
        Block[,] blocks;
        private Vector2i Size = Vector2i.Zero;

        VAO vAO;
        VBO vbo;
        VBO tvbo;
        EBO ebo;

        Texture texture;

        List<Vector3> vertices = new List<Vector3>();
        List<Vector2> texCoords = new List<Vector2>();
        List<uint> indices = new List<uint>();

        uint[] indicesStart = new uint[]
        {
            0, 1, 2,
            0, 2, 3,
        };

        public World(int Width, int Height)
        {
            Size.X = Width;
            Size.Y = Height;

            blocks = new Block[Size.X, Size.Y];

            texture = new Texture(@"C:\Users\DiegoMogger\source\repos\Labirinto Game Engine\Labirinto Game Engine\Game\Shaders\Texture Resources\sla.png");
            texture.Use();

            vAO = new VAO();
            vAO.Bind();

            uint index = 0;
            for (int x = 0; x < Size.X; x++)
            {
                for (int y = 0; y < Size.Y; y++)
                {
                    blocks[x,y] = new Block(new Vector3(x, y, 0));
                    vertices.AddRange(blocks[x, y].vertices);
                    texCoords.AddRange(blocks[x, y].texCoord);

                    indices.Add(index + 0);
                    indices.Add(index + 1);
                    indices.Add(index + 2);

                    indices.Add(index + 0);
                    indices.Add(index + 2);
                    indices.Add(index + 3);

                    index += 4;
                }
            }

            vbo = new VBO(vertices.ToArray(), 0);
            tvbo = new VBO(texCoords.ToArray(), 1);
            ebo = new EBO(indices.ToArray());
        }

        public void Render(Shader shader)
        {
            shader.Use();
            texture.Use();
            shader.Uniform1(texture.texture, "texture0");
            
            vAO.Bind();

            GL.DrawElements(BeginMode.Triangles, indices.Count, DrawElementsType.UnsignedInt, 0);
        }
    }
}
