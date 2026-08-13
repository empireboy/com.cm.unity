using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace CM.Unity.Presentation
{
    [RequireComponent(typeof(TickableInstaller))]
    public class GridActorInteractionInputInstaller : MonoInstaller
    {
        [SerializeField]
        private InputActionAsset _inputActionAsset;

        public override void InstallBindings()
        {
            InputAction interactInputAction = InputSystem.actions.FindAction("Interact");

            Container.Bind<InputAction>()
                .WithId("Interact")
                .FromInstance(interactInputAction)
                .AsSingle();

            Container.Bind<Core.Domain.ITickable>().To<GridActorInteractionInputController>().AsSingle();
        }
    }
}