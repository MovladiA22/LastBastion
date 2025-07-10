using System;
using UnityEngine;
using Common.Interfaces;
using LastBastion.UpgradeSystem;
using System.Collections.Generic;
using Common.UnityUtilities.Behaviors;
using LastBastion.UpgradeSystem.Interfaces;

namespace LastBastion.DefensiveSystem
{
    public class DefensiveWeaponsSystem : ManagedBehavior, IUpgradable
    {
        [SerializeField] private List<DefensiveWeapon> _defensiveWeapons;
        [SerializeField] private Upgrader _weaponAccessUpgrader;

        private DefensiveWeapon _defensiveWeapon;

        public IPayable Payable { get; private set; }
        public UpgradeLevel Level => _weaponAccessUpgrader.Level;
        public IUpgrader Upgrader => _weaponAccessUpgrader;
        public bool IsDefensiveWeaponActivated => _defensiveWeapon != null;

        public override void Init()
        {
            for (int i = 0; i < _defensiveWeapons.Count; i++)
            {
                _defensiveWeapons[i].SetIndex(i);
                _defensiveWeapons[i].gameObject.SetActive(false);
            }

            _weaponAccessUpgrader.SetUpgradable(this);
        }

        public override void Deactivate()
        {
            base.Deactivate();

            TurnOff();
        }

        public void SetPayable(IPayable payable)
        {
            Payable = payable ?? throw new ArgumentNullException(nameof(payable));
        }

        public void TryTurnOn(int defensiveWeaponIndex)
        {
            if (IsActivated == false || (IsDefensiveWeaponActivated && _defensiveWeapon.Index == defensiveWeaponIndex))
                return;
            else if (defensiveWeaponIndex < 0 || defensiveWeaponIndex >= _defensiveWeapons.Count)
                throw new ArgumentOutOfRangeException(nameof(defensiveWeaponIndex));

            if (Payable.TryPay(_defensiveWeapons[defensiveWeaponIndex].Price))
            {
                TurnOff();
                _defensiveWeapon = _defensiveWeapons[defensiveWeaponIndex];
                _defensiveWeapon.gameObject.SetActive(true);
            }
        }

        public void Upgrade() { }

        public void Defend()
        {
            if (IsDefensiveWeaponActivated)
            {
                _defensiveWeapon.Attack();
            }
        }

        private void TurnOff()
        {
            if (IsDefensiveWeaponActivated == false)
                return;

            _defensiveWeapon.gameObject.SetActive(false);
            _defensiveWeapon = null;
        }
    }
}
