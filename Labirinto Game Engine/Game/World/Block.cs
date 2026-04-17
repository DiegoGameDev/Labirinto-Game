using OpenTK.Mathematics;

namespace GameEngine
{
    public class Block
    {
        public Vector3[] vertices;

        public Vector2[] texCoordData;


        public Block(Vector3 position, FaceBlockType faceBlockType = FaceBlockType.Ground2)
        {
            float size = 0.5f;
            vertices = new Vector3[]
            {
            new Vector3(position.X - size, position.Y - size, 0), // bottom-left
            new Vector3(position.X + size, position.Y - size, 0), // bottom-right
            new Vector3(position.X + size, position.Y + size, 0), // top-right
            new Vector3(position.X - size, position.Y + size, 0), // top-left
            };

            texCoordData = FaceData.TexCoordsForFaceData[faceBlockType].ToArray();
        }
    }


}
