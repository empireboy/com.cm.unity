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
        private GridActorSettingsSO _settings;

        [Inject]
        private readonly GridView _gridView;

        [Inject]
        private readonly Core.Domain.Grid _grid;

        protected Int2 Position => _gridView.ToGridPosition(_rootTransform.position);

        protected GridActorSettingsSO Settings => _settings;

        protected Core.Domain.Grid Grid => _grid;

        public override void InstallBindings()
        {
            GridActorState state = CreateState();
            GridActor actor = CreateActor(state);

            Grid.TryOccupy(actor, Position);

            Container.Bind<IGridActor>().FromInstance(actor).AsSingle();

            Container.BindInstance(Settings.entitySettings).AsSingle();
            Container.BindInstance(Settings.actorSettings).AsSingle();

            Container.BindInterfacesAndSelfTo<GridActorFacade>().AsSingle();
        }

        protected virtual void Reset()
        {
            if (!_rootTransform)
                _rootTransform = GetComponentInParent<GameObjectContext>().transform;
        }

        protected virtual GridActorState CreateState()
        {
            return new GridActorState
            {
                Position = Position,
                Direction = Settings.entitySettings.startingDirection
            };
        }

        protected virtual GridActor CreateActor(GridActorState state)
        {
            return new GridActor(state);
        }
    }
}