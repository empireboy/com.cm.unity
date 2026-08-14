using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace CM.Unity.Presentation
{
    [RequireComponent(typeof(TickableInstaller))]
    public class GridActorMovementInputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InputAction moveInputAction = InputSystem.actions.FindAction("Move");

            Container.Bind<InputAction>()
                .WithId("Move")
                .FromInstance(moveInputAction)
                .AsCached();

            Container.Bind<Core.Domain.ITickable>().To<GridActorMovementInputController>().AsSingle();
        }
    }
}