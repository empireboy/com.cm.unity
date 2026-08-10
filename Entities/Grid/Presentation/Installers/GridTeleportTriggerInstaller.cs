using CM.Core.Application;
using CM.Core.Domain;
using UnityEngine;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GridTeleportTriggerInstaller : MonoInstaller
    {
        [SerializeField]
        private int _destinationX;

        [SerializeField]
        private int _destinationY;

        [SerializeField]
        private Direction _destinationDirection;

        [SerializeField]
        private GameObject _rootGameObject;

        [Inject]
        private Core.Domain.Grid _grid;

        [Inject]
        private GridView _gridView;

        [Inject]
        private GridTeleportUseCase _gridTeleportUseCase;

        public override void InstallBindings()
        {
            Int2 position = _gridView.ToGridPosition(_rootGameObject.transform.position);

            GridEntityState gridEntityState = new()
            {
                Position = position,
                Direction = _destinationDirection
            };

            GridActorTeleportTrigger trigger = new(
                gridEntityState,
                new Int2(_destinationX, _destinationY),
                _destinationDirection,
                _gridTeleportUseCase
            );

            Container.Bind<IGridEntity>().FromInstance(trigger).AsSingle();

            _grid.GetCell(position).SetTrigger(trigger);
        }
    }
}