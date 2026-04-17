

using OpenTK.Mathematics;

namespace GameEngine
{
    public struct WorldData
    {
        public Vector3 playerPosition { get; set; }
        public FaceBlockType[,] blocks { get; set; }
        public Vector2i size { get; set; }
    }
}
