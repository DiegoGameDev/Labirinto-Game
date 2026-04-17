using Newtonsoft.Json;
using OpenTK.Mathematics;

namespace GameEngine
{
    public static class WorldDataGenerator
    {
        public static WorldData ReadData(string path)
        {
            if (File.Exists(path))
            {
                string contentFile = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<WorldData>(contentFile);
            }

            return new WorldData();
        }

        public static WorldData WriteWorldData(string gridCharacthers, Vector2i mapSize)
        {
            string[] lines = gridCharacthers.Split("\r\n");

            WorldData worldData = new WorldData();
            worldData.size = mapSize;
            worldData.blocks = new FaceBlockType[mapSize.X, mapSize.Y];

            for (int l = 0; l < lines.Length; l++)
            {
                for (int b = 0; b < lines[l].Length; b++)
                {
                    
                    if (lines[l][b] == '1')
                    {
                        worldData.blocks[b, l] = FaceBlockType.Wall;
                    }
                    if (lines[l][b] == '2')
                    {
                        worldData.blocks[b, l] = FaceBlockType.Ground2;
                    }
                    if (lines[l][b] == '3')
                    {
                        worldData.blocks[b, l] = FaceBlockType.Hole;
                    }
                    if (lines[l][b] == '4')
                    {
                        worldData.blocks[b, l] = FaceBlockType.Ground1;
                    }
                }

            }

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

            };
            string jsonObject = JsonConvert.SerializeObject(worldData, settings);
            File.WriteAllText("insert your file path"{new Guid().Variant}.json", jsonObject);

            return worldData;
        }
    }
}
