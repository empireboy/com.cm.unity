using UnityEngine;
using Zenject;

namespace CM.Unity.Presentation
{
    [RequireComponent(typeof(TickableInstaller))]
    public class GridActorInteractionInputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Core.Domain.ITickable>().To<GridActorInteractionInputController>().AsSingle();
        }
    }
}