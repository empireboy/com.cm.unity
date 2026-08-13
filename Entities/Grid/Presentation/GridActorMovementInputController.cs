using CM.Core.Application;
using CM.Core.Domain;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GridActorMovementInputController : Core.Domain.ITickable
    {
        private readonly GridActorFacade _actorFacade;
        private readonly GameStateManager _gameStateManager;
        private readonly InputAction _moveInputAction;

        public GridActorMovementInputController(GridActorFacade facade, GameStateManager gameStateManager, [Inject(Id = "Move")] InputAction moveInputAction)
        {
            _actorFacade = facade;
            _gameStateManager = gameStateManager;
            _moveInputAction = moveInputAction;

            _actorFacade.MovementFinished += OnMovementFinished;
        }

        public void Tick()
        {
            if (_gameStateManager.Current != GameStates.Gameplay)
                return;

            if (_actorFacade.IsMoving)
                return;

            TryMoveFromInput();
        }

        private void TryMoveFromInput()
        {
            Vector2 input = _moveInputAction.ReadValue<Vector2>();

            Direction direction = GetInputDirection(input);

            if (direction == Direction.None)
            {
                _actorFacade.SetMoving(false);
                return;
            }

            bool moved = _actorFacade.TryMove(direction);

            if (!moved)
                _actorFacade.SetMoving(false);
        }

        private Direction GetInputDirection(Vector2 input)
        {
            if (input.y > 0)
                return Direction.Up;

            if (input.y < 0)
                return Direction.Down;

            if (input.x < 0)
                return Direction.Left;

            if (input.x > 0)
                return Direction.Right;

            return Direction.None;
        }

        private void OnMovementFinished()
        {
            TryMoveFromInput();
        }
    }
}