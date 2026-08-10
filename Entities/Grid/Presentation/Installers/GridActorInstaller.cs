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
        private Transform _rootTransform;

        [SerializeField]
        private GridActorSettingsSO _actorSettings;

        [Inject]
        private GridView _gridView;

        [Inject]
        private Core.Domain.Grid _grid;

        public override void InstallBindings()
        {
            Int2 position = _gridView.ToGridPosition(_rootTransform.position);

            GridActorState gridActorState = new()
            {
                Position = position,
                Direction = _actorSettings.settings.direction
            };

            GridActor gridActor = new(gridActorState);

            _grid.TryOccupy(gridActor, position);

            Container.Bind<IGridActor>().FromInstance(gridActor).AsSingle();

            Container.BindInstance(_actorSettings.settings).AsSingle();

            // Facade
            Container.BindInterfacesAndSelfTo<GridActorFacade>().AsSingle();
        }
    }
}