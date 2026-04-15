using GameEngine.Object;

namespace GameEngine
{
    public abstract class Component
    {
        protected List<Component> Components = new List<Component>();
        public Component()
        {
            Components.Add(this);
        }

        public bool HasComponent <T>(out Component? value) where T : Component
        {
            foreach (var i in Components)
            {
                if (typeof(T) == i.GetType())
                {
                    value = i;
                    return true;
                }
            }

            value = default;
            return false;
        }
    }
}
