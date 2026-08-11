using CM.Core.Application;
using CM.Core.Domain;
using UnityEngine;

namespace CM.Unity.Presentation
{
    public class GridActorMovementInputController : ITickable
    {
        private readonly GridActorFacade _actorFacade;

        public GridActorMovementInputController(GridActorFacade facade)
        {
            _actorFacade = facade;

            _actorFacade.MovementFinished += OnMovementFinished;
        }

        public void Tick()
        {
            if (_actorFacade.IsMoving)
                return;

            TryMoveFromInput();
        }

        private void TryMoveFromInput()
        {
            Direction direction = GetInputDirection();

            if (direction == Direction.None)
            {
                _actorFacade.SetMoving(false);
                return;
            }

            bool moved = _actorFacade.TryMove(direction);

            if (!moved)
                _actorFacade.SetMoving(false);
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