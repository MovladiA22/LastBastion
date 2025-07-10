using Common.UnityUtilities.Coroutines;
using UnityEngine;

namespace LastBastion.CombatSystem
{
    internal class DoubleAttackSystem : AttackSystem
    {
        [SerializeField, Min(0.01f)] private float _delayBetweenTwoAttacks;

        private CoroutineTimer _secondAttackDelayTimer;

        protected override void Awake()
        {
            base.Awake();

            _secondAttackDelayTimer = new CoroutineTimer(this, _delayBetweenTwoAttacks, DelayDamage);
        }

        protected override void Attack()
        {
            if (CooldownTimer.IsTimeUp == false)
                return;

            Invoke(nameof(PlayAttackSound), _delayBetweenTwoAttacks);
            base.Attack();

            _secondAttackDelayTimer.Run();
        }

        protected override void DelayDamage()
        {
            base.DelayDamage();

            Damager.DealDamage(KeeperOpponents.GetFirstOpponent());
        }

        private void PlayAttackSound() =>
            AttackSound.Play();
    }
}
