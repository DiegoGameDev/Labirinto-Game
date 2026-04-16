using OpenTK.Mathematics;

namespace GameEngine
{
    public class Block
    {
        public Vector3[] vertices;

        public Vector2[] texCoord =
        {
            new Vector2(0, 0),
            new Vector2(1f / 2f, 0),
            new Vector2(1f / 2f, 1f),
            new Vector2(0, 1f),
        };


        public Block(Vector3 position)
        {
            float size = 0.5f;
            vertices = new Vector3[]
            {
            new Vector3(position.X - size, position.Y - size, 0), // bottom-left
            new Vector3(position.X + size, position.Y - size, 0), // bottom-right
            new Vector3(position.X + size, position.Y + size, 0), // top-right
            new Vector3(position.X - size, position.Y + size, 0), // top-left
            };
        }
    }
}
