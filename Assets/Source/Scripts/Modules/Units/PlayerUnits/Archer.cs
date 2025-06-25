using LastBastion.CombatSystem;
using System;

namespace LastBastion.Units
{
    public class Archer : PlayerUnit
    {
        private RangedWeaponSystem _rangedWeaponSystem;

        protected override void Awake()
        {
            base.Awake();

            _rangedWeaponSystem = AttackSystem as RangedWeaponSystem ?? throw new ArgumentNullException(nameof(_rangedWeaponSystem));
        }
    }
}
