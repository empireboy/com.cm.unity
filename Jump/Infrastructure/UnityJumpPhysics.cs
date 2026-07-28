using CM.Core.Interfaces;
using UnityEngine;

namespace CM.Unity.Infrastructure
{
    public class UnityJumpPhysics : IJumpPhysics
    {
        private readonly Rigidbody _rigidbody;

        public UnityJumpPhysics(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Jump(float force)
        {
            _rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}