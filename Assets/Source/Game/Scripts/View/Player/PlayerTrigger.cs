using LastBastion.View.Interface;
using UnityEngine;

namespace LastBastion.View
{
    public class PlayerTrigger : AttackTrigger
    {
        protected override bool IsRightDamageable(Collider2D collision)
        {
            if (collision.TryGetComponent<IPlayer>(out IPlayer player))
                return true;

            return false;
        }
    }
}
