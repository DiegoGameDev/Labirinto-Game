namespace GameEngine.Object
{
    public class GameObject : Component
    {
        public Transform transform = new Transform();

        public GameObject()
        {
            Components.Add(transform);
        }
    }
}
