using CM.Core.Application;
using CM.Core.Domain;
using UnityEngine;

namespace CM.Unity.Presentation
{
    public class GridEntityMovementController : IGridEntityMovementController
    {
        private readonly GridEntityFacade _entityFacade;

        public GridEntityMovementController(GridEntityFacade facade)
        {
            _entityFacade = facade;

            _entityFacade.MovementFinished += OnMovementFinished;
        }

        public void Tick()
        {
            if (_entityFacade.IsMoving)
                return;

            TryMoveFromInput();
        }

        private void TryMoveFromInput()
        {
            Direction direction = GetInputDirection();

            if (direction == Direction.None)
            {
                _entityFacade.SetMoving(false);
                return;
            }

            bool moved = _entityFacade.TryMove(direction);

            if (!moved)
                _entityFacade.SetMoving(false);
        }

        private Direction GetInputDirection()
        {
            if (Input.GetKey(KeyCode.UpArrow))
                return Direction.Up;

            if (Input.GetKey(KeyCode.DownArrow))
                return Direction.Down;

            if (Input.GetKey(KeyCode.LeftArrow))
                return Direction.Left;

            if (Input.GetKey(KeyCode.RightArrow))
                return Direction.Right;

            return Direction.None;
        }

        private void OnMovementFinished()
        {
            TryMoveFromInput();
        }
    }
}