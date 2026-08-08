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

        public override void InstallBindings()
        {
            GridActorState gridActorState = new()
            {
                Position = new Int2(0, 0),
                Direction = Direction.Down
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