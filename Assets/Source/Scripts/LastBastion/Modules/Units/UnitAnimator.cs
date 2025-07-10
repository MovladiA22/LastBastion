using UnityEngine;

namespace LastBastion.Units
{
    public class UnitAnimator : MonoBehaviour
    {
        private readonly int _isWalk = Animator.StringToHash(nameof(_isWalk));
        private readonly int _attack = Animator.StringToHash(nameof(_attack));

        [SerializeField] private Unit _unit;
        [SerializeField] private Animator _animator;

        private void OnEnable()
        {
            _unit.OnIsMoved += OnToggleWalk;
            _unit.OnAttacked += OnActivateAttack;
        }

        private void OnDisable()
        {
            _unit.OnIsMoved -= OnToggleWalk;
            _unit.OnAttacked -= OnActivateAttack;
        }

        private void OnToggleWalk(bool isMoved) =>
            _animator.SetBool(_isWalk, isMoved);

        private void OnActivateAttack() =>
            _animator.SetTrigger(_attack);
    }
}
