using UnityEngine;
using Zenject;

namespace CM.Unity.Presentation
{
    [RequireComponent(typeof(TickableInstaller))]
    public class GridActorMovementInputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Core.Domain.ITickable>().To<GridActorMovementInputController>().AsSingle();
        }
    }
}