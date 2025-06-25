using System;
using UnityEngine;

namespace LastBastion.CombatSystem
{
    public class ProjectileOutOfBoundsTrigger : MonoBehaviour
    {
        private Projectile _projectile;

        public void SetProjectile(Projectile projectile) =>
            _projectile = projectile != null ? projectile : throw new ArgumentNullException(nameof(projectile));

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Projectile projectile) && projectile == _projectile)
                projectile.InvokeReleaseEvent();
        }
    }
}
