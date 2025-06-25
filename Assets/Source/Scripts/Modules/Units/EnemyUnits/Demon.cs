using LastBastion.CombatSystem;
using UnityEngine;

namespace LastBastion.Units
{
    public class Demon : EnemyUnit
    {
        [SerializeField] private AreaAttackSystem _areaAttackSystem;
        [SerializeField] private ParticleSystem _particleSystem;

        private int _minNumberOfOpponents = 2;

        protected override void OnEnable()
        {
            base.OnEnable();

            AttackSystem.OnAttacked += TryAreaAttack;
            _areaAttackSystem.OnAttacked += OnActivateEffect;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            AttackSystem.OnAttacked -= TryAreaAttack;
            _areaAttackSystem.OnAttacked -= OnActivateEffect;
        }

        private void TryAreaAttack()
        {
            Debug.Log(_areaAttackSystem.KeeperOpponents.GetAllOpponents().Count);
            if (_areaAttackSystem.KeeperOpponents.GetAllOpponents().Count >= _minNumberOfOpponents)
                _areaAttackSystem.TryAttack();
        }

        private void OnActivateEffect() =>
            _particleSystem.Play();
    }
}
