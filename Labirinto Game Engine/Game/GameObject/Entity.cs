using GameEngine.Shaders;

namespace GameEngine.Object
{
    public abstract class Entity : Component
    {
        public string entityName { get; protected set; } = string.Empty;

        public Transform transform = new Transform();

        protected Entity()
        {
            Components.Add(transform);
        }

        public virtual void RenderEntity(Shader shader)
        {

        }
    }
}
