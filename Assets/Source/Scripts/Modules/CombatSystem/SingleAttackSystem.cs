using System.Collections;

namespace LastBastion.CombatSystem
{
    public class SingleAttackSystem : AttackSystem
    {
        protected override void DelayDamage()
        {
            base.DelayDamage();

            Damager.DealDamage(KeeperOpponents.GetFirstOpponent());
        }
    }
}
