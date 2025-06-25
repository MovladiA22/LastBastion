using LastBastion.CombatSystem;

namespace LastBastion.Bases
{
    public class EnemyBase : Base, IEnemy
    {
        public override void Activate()
        {
            if (IsActivated == false)
                gameObject.SetActive(true);

            base.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();

            gameObject.SetActive(false);
        }
    }
}
