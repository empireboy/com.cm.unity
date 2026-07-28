using CM.Core.Domain;
using CM.Core.Interfaces;
using UnityEngine;

namespace CM.Unity.Infrastructure
{
    public class UnityMovePhysics : IMovePhysics
    {
        private readonly Rigidbody _rigidbody;

        public UnityMovePhysics(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Move(Float2 directionFloat2)
        {
            Vector3 direction = directionFloat2.ToVector3();

            _rigidbody.AddForce(direction);
        }
    }
}