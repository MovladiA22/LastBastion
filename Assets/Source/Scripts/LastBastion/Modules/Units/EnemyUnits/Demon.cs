using LastBastion.CombatSystem;
using UnityEngine;

namespace LastBastion.Units.EnemyUnits
{
    public class Demon : EnemyUnit
    {
        private const int MinNumberOfOpponents = 2;

        [SerializeField] private AreaAttackSystem _areaAttackSystem;
        [SerializeField] private ParticleSystem _particleSystem;

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
            if (_areaAttackSystem.KeeperOpponents.GetAllOpponents().Count >= MinNumberOfOpponents)
                _areaAttackSystem.TryAttack();
        }

        private void OnActivateEffect() =>
            _particleSystem.Play();
    }
}
