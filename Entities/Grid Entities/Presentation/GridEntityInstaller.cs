using CM.Core.Application;
using CM.Core.Domain;
using CM.Unity.Infrastructure;
using UnityEngine;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GridEntityInstaller : MonoInstaller
    {
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private GridEntitySettingsSO _entitySettings;

        public override void InstallBindings()
        {
            GridEntity gridEntity = new(new Int2(0, 0), Direction.Down);

            Container.Bind<IGridEntity>().FromInstance(gridEntity);
            Container.Bind<GridMovementUseCase>().AsSingle();
            Container.Bind<GridTeleportUseCase>().AsSingle();

            Container.Bind<Animator>().FromInstance(_animator);

            Container.BindInstance(_entitySettings.settings).AsSingle();

            // Facade
            Container.BindInterfacesAndSelfTo<GridEntityFacade>().AsSingle();

            Container.Bind<Core.Domain.ITickable>().To<GridEntityMovementController>().AsSingle();

            Container.BindInterfacesTo<TickableAdapter>().AsSingle();
        }
    }
}