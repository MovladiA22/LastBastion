using UnityEngine;

namespace LastBastion.CombatSystem
{
    public abstract class PlayerProjectile : Projectile
    {
        protected override void FixHit(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<IEnemy>(out _))
                base.FixHit(collision);
        }

        protected override bool HaveObstaclesBeenFound(RaycastHit2D[] hits)
        {
            foreach (var hit in hits)
            {
                if (hit.collider.isTrigger || hit.collider.TryGetComponent<IPlayer>(out _))
                    return false;
            }

            return false;
        }
    }
}
