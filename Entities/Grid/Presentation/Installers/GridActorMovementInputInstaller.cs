using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace CM.Unity.Presentation
{
    [RequireComponent(typeof(TickableInstaller))]
    public class GridActorMovementInputInstaller : MonoInstaller
    {
        [SerializeField]
        private InputActionAsset _inputActionAsset;

        public override void InstallBindings()
        {
            InputAction moveInputAction = InputSystem.actions.FindAction("Move");

            Container.Bind<InputAction>()
                .WithId("Move")
                .FromInstance(moveInputAction)
                .AsSingle();

            Container.Bind<Core.Domain.ITickable>().To<GridActorMovementInputController>().AsSingle();
        }

        private void OnEnable()
        {
            _inputActionAsset.FindActionMap("Gameplay").Enable();
        }

        private void OnDisable()
        {
            _inputActionAsset.FindActionMap("Gameplay").Disable();
        }
    }
}