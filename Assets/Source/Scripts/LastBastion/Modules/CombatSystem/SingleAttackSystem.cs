namespace LastBastion.CombatSystem
{
    internal class SingleAttackSystem : AttackSystem
    {
        protected override void DelayDamage()
        {
            base.DelayDamage();

            Damager.DealDamage(KeeperOpponents.GetFirstOpponent());
        }
    }
}
