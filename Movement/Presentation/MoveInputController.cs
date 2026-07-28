using CM.Core.Domain;
using CM.Core.Interfaces;
using UnityEngine;

namespace CM.Unity.Presentation
{
    public class MoveInputController : IMovementInput, Zenject.ITickable
    {
        public Float2 Direction { get; private set; }

        public void Tick()
        {
            Direction = new(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            );
        }
    }
}