using CM.Core.Application;
using CM.Core.Domain;
using UnityEngine;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GridActorView : MonoBehaviour
    {
        private static readonly int IsMovingHash = Animator.StringToHash("IsMoving");
        private static readonly int DirectionXHash = Animator.StringToHash("DirectionX");
        private static readonly int DirectionYHash = Animator.StringToHash("DirectionY");

        [Inject]
        private readonly GridActorFacade _actorFacade;

        [Inject]
        private readonly GridActorSettings _actorSettings;

        [Inject]
        private readonly GridView _gridView;

        [Inject]
        private readonly Animator _animator;

        private Vector3 _targetPosition;

        private void Start()
        {
            OnPositionChanged(_actorFacade.Position);
            SetAnimationDirection(_actorFacade.Direction.ToInt2());
        }

        private void Update()
        {
            if (transform.position != _targetPosition)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    _targetPosition,
                    _actorSettings.moveSpeed * Time.deltaTime
                );

                return;
            }

            if (_actorFacade.IsMoving)
            {
                _actorFacade.NotifyTileReached();
                _actorFacade.NotifyMovementFinished();
            }
        }

        private void SetAnimationDirection(Int2 direction)
        {
            _animator.SetFloat(DirectionXHash, direction.x);
            _animator.SetFloat(DirectionYHash, direction.y);
        }

        private void SetMoving(bool moving)
        {
            _animator.SetBool(IsMovingHash, moving);
        }

        private void OnPositionChanged(Int2 position)
        {
            _targetPosition = _gridView.ToWorldPosition(position);
        }

        private void OnDirectionChanged(Direction direction)
        {
            SetAnimationDirection(direction.ToInt2());
        }

        private void OnMovementStateChanged(bool isMoving)
        {
            SetMoving(isMoving);
        }

        private void OnTeleported(Int2 position)
        {
            OnPositionChanged(position);

            transform.position = _targetPosition;
        }

        private void OnEnable()
        {
            _actorFacade.PositionChanged += OnPositionChanged;
            _actorFacade.DirectionChanged += OnDirectionChanged;
            _actorFacade.MovementStateChanged += OnMovementStateChanged;
            _actorFacade.Teleported += OnTeleported;
        }

        private void OnDisable()
        {
            _actorFacade.PositionChanged -= OnPositionChanged;
            _actorFacade.DirectionChanged -= OnDirectionChanged;
            _actorFacade.MovementStateChanged -= OnMovementStateChanged;
            _actorFacade.Teleported -= OnTeleported;
        }

#if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            if (_actorFacade == null || _gridView == null)
                return;

            Vector3 position = _gridView.ToWorldPosition(_actorFacade.Position);

            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(position, new Vector3(0.32f, 0.32f, 0f));
        }

#endif

    }
}