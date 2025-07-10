using LastBastion.CombatSystem.Projectiles;
using UnityEngine;
using System;

namespace LastBastion.CombatSystem.Triggers
{
    internal class ProjectileOutOfBoundsTrigger : MonoBehaviour
    {
        private Projectile _projectile;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Projectile projectile) && projectile == _projectile)
                projectile.InvokeReleaseEvent();
        }

        public void SetProjectile(Projectile projectile) =>
            _projectile = projectile != null ? projectile : throw new ArgumentNullException(nameof(projectile));
    }
}
