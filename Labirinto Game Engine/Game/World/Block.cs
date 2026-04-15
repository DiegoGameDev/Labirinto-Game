using OpenTK.Mathematics;

namespace GameEngine
{
    public class Block
    {
        public Vector2[] vertices = new Vector2[4];

        public Block(Vector2 position, float size = 0.5f)
        {
            vertices = new Vector2[]
            {
            new Vector2(position.X - size, position.Y - size), // bottom-left
            new Vector2(position.X + size, position.Y - size), // bottom-right
            new Vector2(position.X + size, position.Y + size), // top-right
            new Vector2(position.X - size, position.Y + size) // top-left
            };
        }
    }
}
