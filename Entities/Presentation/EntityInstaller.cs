using CM.Core.Domain;
using UnityEngine;

namespace CM.Unity.Presentation
{
    [DefaultExecutionOrder(-100)]
    public abstract class EntityInstaller<TContext> : MonoBehaviour where TContext : struct
    {
        public abstract void Install(Entity entity, TContext context);
    }
}