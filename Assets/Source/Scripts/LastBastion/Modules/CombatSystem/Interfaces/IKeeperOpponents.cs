using System.Collections.Generic;

namespace LastBastion.CombatSystem.Interfaces
{
    public interface IKeeperOpponents
    {
        IDamageable GetFirstOpponent();
        IReadOnlyList<IDamageable> GetAllOpponents();
    }
}
