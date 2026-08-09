using CM.Core.Application;
using CM.Core.Domain;
using CM.Unity.Infrastructure;
using UnityEngine;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GridActorInstaller : MonoInstaller
    {
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private GridActorSettingsSO _actorSettings;

        [Inject]
        private GridView _gridView;

        public override void InstallBindings()
        {
            Int2 position = _gridView.ToGridPosition(_animator.transform.position);

            GridActorState gridActorState = new()
            {
                Position = position,
                Direction = _actorSettings.settings.direction
            };

            GridActor gridActor = new(gridActorState);

            Container.Bind<IGridActor>().FromInstance(gridActor).AsSingle();

            Container.Bind<Animator>().FromInstance(_animator).AsSingle();

            Container.BindInstance(_actorSettings.settings).AsSingle();

            // Facade
            Container.BindInterfacesAndSelfTo<GridActorFacade>().AsSingle();

            Container.Bind<Core.Domain.ITickable>().To<GridActorMovementController>().AsSingle();

            Container.BindInterfacesTo<TickableAdapter>().AsSingle();
        }
    }
}