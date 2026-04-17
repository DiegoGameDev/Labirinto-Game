using OpenTK.Mathematics;

namespace GameEngine;

public struct FaceData
{
    public static Dictionary<FaceBlockType, List<Vector2>> TexCoordsForFaceData { get; set; } = new Dictionary<FaceBlockType, List<Vector2>>()
    {
        {
            FaceBlockType.Wall,
            new List<Vector2>()
            {
                new Vector2(0, 15f / 16f),
                new Vector2(1f / 16f, 15f / 16f),
                new Vector2(1f / 16f, 16f / 16f),
                new Vector2(0, 16f / 16f),
            }
        },
        {
            FaceBlockType.Ground2,
            new List<Vector2>()
            {
                new Vector2(1f / 16f, 15f / 16f),
                new Vector2(2f / 16f, 15f / 16f),
                new Vector2(1f / 16f, 16f / 16f),
                new Vector2(2f / 16f, 16f / 16f),
            }
        },
        {
            FaceBlockType.Hole,
            new List<Vector2>()
            {
                new Vector2(2f / 16f, 15f / 16f),
                new Vector2(3f / 16f, 15f / 16f),
                new Vector2(2f / 16f, 16f / 16f),
                new Vector2(3f / 16f, 16f / 16f),
            }
        },
        {
            FaceBlockType.Ground1,
            new List<Vector2>()
            {
                new Vector2(3f / 16f, 15f / 16f),
                new Vector2(4f / 16f, 15f / 16f),
                new Vector2(3f / 16f, 16f / 16f),
                new Vector2(4f / 16f, 16f / 16f),
            }
        },
    };
}

public enum FaceBlockType
{
    Wall,
    Ground1,
    Ground2,
    Hole,

}

public enum BehaviourBlock
{
    Static,
    Dynamic
}