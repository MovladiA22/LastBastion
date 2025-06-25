using System;
using UnityEngine;
using Common.Interfaces;
using LastBastion.UpgradeSystem;
using System.Collections.Generic;
using LastBastion.DefensiveWeapons;

namespace LastBastion.Bases
{
    public class DefensiveSystem : ManagedBehavior, IUpgradable
    {
        [SerializeField] private List<DefensiveWeapon> _defensiveWeapons;
        [SerializeField] private Upgrader _weaponAccessUpgrader;

        private DefensiveWeapon _defensiveWeapon;

        public IPayable Payable { get; private set; }
        public Level Level => _weaponAccessUpgrader.Level;
        public IUpgrader Upgrader => _weaponAccessUpgrader;
        public bool IsDefensiveWeaponActivated => _defensiveWeapon != null;

        public override void Init()
        {
            for (int i = 0; i < _defensiveWeapons.Count; i++)
            {
                _defensiveWeapons[i].SetIndex(i);
            }

            _weaponAccessUpgrader.SetUpgradable(this);
        }

        public void SetPayable(IPayable payable)
        {
            Payable = payable ?? throw new ArgumentNullException(nameof(payable));
        }

        public void TryTurnOn(int defensiveWeaponIndex)
        {
            if (IsActivated == false)
                return;

            if (IsDefensiveWeaponActivated && _defensiveWeapon.Index != defensiveWeaponIndex)
                TurnOff();
            else if (defensiveWeaponIndex < 0 || defensiveWeaponIndex >= _defensiveWeapons.Count)
                throw new ArgumentOutOfRangeException(nameof(defensiveWeaponIndex));
            else if (IsDefensiveWeaponActivated && _defensiveWeapon.Index == defensiveWeaponIndex)
                return;

            if (Payable.TryPay(_defensiveWeapons[defensiveWeaponIndex].Price) == false)
                return;

            _defensiveWeapon = _defensiveWeapons[defensiveWeaponIndex];
            _defensiveWeapon.gameObject.SetActive(true);
        }

        private void TurnOff()
        {
            if (IsDefensiveWeaponActivated == false)
                return;

            _defensiveWeapon.gameObject.SetActive(false);
            _defensiveWeapon = null;
        }

        public void Upgrade() { }

        public override void Activate()
        {
            base.Activate();

            foreach (var weapon in _defensiveWeapons)
                weapon.gameObject.SetActive(false);
        }

        public override void Deactivate()
        {
            base.Deactivate();

            TurnOff();
        }

        public void Defend()
        {
            if (IsDefensiveWeaponActivated)
            {
                _defensiveWeapon.Attack();
            }
        }
    }
}
