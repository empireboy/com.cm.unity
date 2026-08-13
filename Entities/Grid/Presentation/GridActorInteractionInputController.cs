using CM.Core.Application;
using CM.Core.Domain;
using UnityEngine.InputSystem;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GridActorInteractionInputController : Core.Domain.ITickable
    {
        private readonly GridActorFacade _actorFacade;
        private readonly GameStateManager _gameStateManager;
        private readonly InputAction _interactInputAction;

        public GridActorInteractionInputController(GridActorFacade facade, GameStateManager gameStateManager, [Inject(Id = "Interact")] InputAction InteractInputAction)
        {
            _actorFacade = facade;
            _gameStateManager = gameStateManager;
            _interactInputAction = InteractInputAction;
        }

        public void Tick()
        {
            if (_gameStateManager.Current != GameStates.Gameplay)
                return;

            if (_actorFacade.IsMoving)
                return;

            if (_interactInputAction.WasPressedThisFrame())
                _actorFacade.TryInteract();
        }
    }
}