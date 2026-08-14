using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace CM.Unity.Presentation
{
    [RequireComponent(typeof(TickableInstaller))]
    public class GridActorInteractionInputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InputAction interactInputAction = InputSystem.actions.FindAction("Interact");

            Container.Bind<InputAction>()
                .WithId("Interact")
                .FromInstance(interactInputAction)
                .AsCached();

            Container.Bind<Core.Domain.ITickable>().To<GridActorInteractionInputController>().AsSingle();
        }
    }
}