using CM.Core.Application;
using CM.Core.Domain;
using UnityEngine;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GridEntityView : MonoBehaviour
    {
        private static readonly int IsMovingHash = Animator.StringToHash("IsMoving");
        private static readonly int DirectionXHash = Animator.StringToHash("DirectionX");
        private static readonly int DirectionYHash = Animator.StringToHash("DirectionY");

        [Inject]
        private GridEntityFacade _entityFacade;

        [Inject]
        private GridEntitySettings _entitySettings;

        [Inject]
        private GridView _gridView;

        [Inject]
        private Animator _animator;

        private Vector3 _targetPosition;

        private void Start()
        {
            _entityFacade.TryTeleport(new Int2(15, 9), Direction.Down);
            _targetPosition = _gridView.ToWorldPosition(_entityFacade.Position);
            transform.position = _targetPosition;
            SetAnimationDirection(_entityFacade.Direction.ToInt2());
        }

        private void Update()
        {
            if (transform.position != _targetPosition)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    _targetPosition,
                    _entitySettings.moveSpeed * Time.deltaTime
                );

                return;
            }

            if (_entityFacade.IsMoving)
                _entityFacade.NotifyMovementFinished();
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

        private void OnEnable()
        {
            _entityFacade.PositionChanged += OnPositionChanged;
            _entityFacade.DirectionChanged += OnDirectionChanged;
            _entityFacade.MovementStateChanged += OnMovementStateChanged;
        }

        private void OnDisable()
        {
            _entityFacade.PositionChanged -= OnPositionChanged;
            _entityFacade.DirectionChanged -= OnDirectionChanged;
            _entityFacade.MovementStateChanged -= OnMovementStateChanged;
        }

#if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            if (_entityFacade == null || _gridView == null)
                return;

            Vector3 position = _gridView.ToWorldPosition(_entityFacade.Position);

            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(position, new Vector3(0.32f, 0.32f, 0f));
        }

#endif

    }
}