using CM.Core.Application;
using CM.Core.Domain;
using UnityEngine;

namespace CM.Unity.Presentation
{
    public class GridActorInteractionInputController : ITickable
    {
        private readonly GridActorFacade _actorFacade;

        public GridActorInteractionInputController(GridActorFacade facade)
        {
            _actorFacade = facade;
        }

        public void Tick()
        {
            if (_actorFacade.IsMoving)
                return;

            if (Input.GetKeyDown(KeyCode.Z))
                _actorFacade.TryInteract();
        }
    }
}