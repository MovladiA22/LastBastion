using UnityEngine;
using UnityUtilities.Coroutines;

namespace LastBastion.CombatSystem
{
    public class DoubleAttackSystem : AttackSystem
    {
        [SerializeField, Min(0.01f)] private float _delayBetweenTwoAttacks;

        private CoroutineTimer _coroutineTimer;

        protected override void Awake()
        {
            base.Awake();

            _coroutineTimer = new CoroutineTimer(this, _delayBetweenTwoAttacks, DelayDamage);
        }

        protected override void Attack()
        {
            if (CooldownTimer.IsTimeUp == false)
                return;

            Invoke(nameof(PlayAttackSound), _delayBetweenTwoAttacks);
            base.Attack();

            _coroutineTimer.Run();
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
