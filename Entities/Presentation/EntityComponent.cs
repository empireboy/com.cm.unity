using CM.Core.Domain;
using UnityEngine;

namespace CM.Unity.Presentation
{
    public class EntityComponent : MonoBehaviour
    {
        public Entity Entity { get; } = new();

        protected virtual void Update()
        {
            foreach (ITickable tickable in Entity.GetTickables())
                tickable.Tick();
        }
    }
}