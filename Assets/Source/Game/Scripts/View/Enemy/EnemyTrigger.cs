using LastBastion.View.Interface;
using UnityEngine;

namespace LastBastion.View
{
    public class EnemyTrigger : AttackTrigger
    {
        protected override bool IsRightDamageable(Collider2D collision)
        {
            if (collision.TryGetComponent<IEnemy>(out IEnemy enemy))
                return true;

            return false;
        }
    }
}
