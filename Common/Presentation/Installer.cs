using UnityEngine;

namespace CM.Unity.Presentation
{
    [DefaultExecutionOrder(-100)]
    public abstract class Installer<TContext> : MonoBehaviour where TContext : struct
    {
        public abstract void Install(TContext context);
    }
}