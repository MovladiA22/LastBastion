using System.Collections;
using System.Linq;

namespace LastBastion.CombatSystem
{
    public class AreaAttackSystem : AttackSystem
    {
        protected override void DelayDamage()
        {
            base.DelayDamage();

            var opponentsCopy = KeeperOpponents.GetAllOpponents().ToList();

            foreach (var opponent in opponentsCopy)
            {
                if (opponent == null)
                    continue;

                Damager.DealDamage(opponent);
            }
        }
    }
}
