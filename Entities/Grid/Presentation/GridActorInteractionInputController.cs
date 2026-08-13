using CM.Core.Application;
using CM.Core.Domain;
using UnityEngine;

namespace CM.Unity.Presentation
{
    public class GridActorInteractionInputController : ITickable
    {
        private readonly GridActorFacade _actorFacade;
        private readonly GameStateManager _gameStateManager;

        public GridActorInteractionInputController(GridActorFacade facade, GameStateManager gameStateManager)
        {
            _actorFacade = facade;
            _gameStateManager = gameStateManager;
        }

        public void Tick()
        {
            if (_gameStateManager.Current != GameStates.Gameplay)
                return;

            if (_actorFacade.IsMoving)
                return;

            if (Input.GetKeyDown(KeyCode.Z))
                _actorFacade.TryInteract();
        }
    }
}