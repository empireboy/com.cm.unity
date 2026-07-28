using CM.Core.Application;
using UnityEngine;
using Zenject;

namespace CM.Unity.Presentation
{
    public class JumpInputController : ITickable
    {
        private readonly JumpUseCase _jumpUseCase;

        public JumpInputController(JumpUseCase jumpUseCase)
        {
            _jumpUseCase = jumpUseCase;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jumpUseCase.Jump();
            }
        }
    }
}