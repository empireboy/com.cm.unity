using CM.Core.Application;
using CM.Core.Interfaces;
using UnityEngine;
using Zenject;

namespace CM.Unity.Presentation
{
    public class CharacterComponent : MonoBehaviour, ICharacter
    {
        public void Jump() => _facade.Jump();
        public void SetMovementInput(IMovementInput movementInput) => _facade.SetMovementInput(movementInput);

        [Inject]
        private CharacterFacade _facade;
    }
}