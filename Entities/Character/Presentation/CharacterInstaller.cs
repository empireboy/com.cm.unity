using CM.Core.Application;
using CM.Core.Domain;
using CM.Core.Interfaces;
using CM.Unity.Infrastructure;
using UnityEngine;
using Zenject;

namespace CM.Unity.Presentation
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        [SerializeField]
        private CharacterSettingsSO _characterSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(_rigidbody).AsSingle();

            // Jumping
            Container.BindInstance(_characterSettings.jumpSettings).AsSingle();
            Container.Bind<JumpState>().AsSingle();
            Container.Bind<JumpUseCase>().AsSingle();
            Container.Bind<IJumpPhysics>().To<UnityJumpPhysics>().AsSingle();
            Container.Bind<Zenject.ITickable>().To<JumpInputController>().AsSingle();

            // Movement
            Container.BindInstance(_characterSettings.movementSettings).AsSingle();
            Container.Bind<MoveState>().AsSingle();
            Container.Bind<MoveUseCase>().AsSingle();
            Container.Bind<IMovePhysics>().To<UnityMovePhysics>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveInputController>().AsSingle();

            // Facade
            Container.Bind<CharacterFacade>().AsSingle();
            Container.Bind<CM.Core.Domain.ITickable>().To<CharacterFacade>().FromResolve();

            Container.BindInterfacesTo<TickableAdapter>().AsSingle();
        }
    }
}