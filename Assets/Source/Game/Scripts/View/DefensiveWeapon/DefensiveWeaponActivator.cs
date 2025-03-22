using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    internal class DefensiveWeaponActivator : MonoBehaviour
    {
        [SerializeField] private List<DefensiveWeapon> _defensiveWeapons;
        [SerializeField] private CoroutineView _defendCoroutin;

        private DefensiveWeapon _defensiveWeapon;
        private bool _areAnyOpponents = false;
        private YieldInstruction _wait;
        private float _updateTime = 0.1f;

        private void Awake()
        {
            foreach (var defensiveWeapon in _defensiveWeapons)
            {
                defensiveWeapon.gameObject.SetActive(false);
            }

            _wait = new WaitForSeconds(_updateTime);
            _defendCoroutin.CreateCoroutine(Defending());
        }

        public void Activate(int defensiveWeaponID)
        {
            if (_defensiveWeapon != null)
                Deactivate();

            _defensiveWeapon = _defensiveWeapons.Find(w => w.ID == defensiveWeaponID);

            if (_defensiveWeapon == null)
                throw new ArgumentNullException(nameof(_defensiveWeapon));

            _defensiveWeapon.gameObject.SetActive(true);

            _defensiveWeapon.OnDetectedEnemy += StartDefending;
            _defensiveWeapon.OnOpponentsAreOver += StopDefending;
        }

        public void Deactivate()
        {
            if (_defensiveWeapon == null)
                return;

            _defensiveWeapon.OnDetectedEnemy -= StartDefending;
            _defensiveWeapon.OnOpponentsAreOver -= StopDefending;

            if (_areAnyOpponents)
                StopDefending();

            _defensiveWeapon.gameObject.SetActive(false);
            _defensiveWeapon = null;
        }

        private void StartDefending()
        {
            if (_areAnyOpponents == false)
            {
                _areAnyOpponents = true;
                _defendCoroutin.Run();
            }
        }

        private void StopDefending()
        {
            _defendCoroutin.Cancel();
            _areAnyOpponents = false;
        }

        private IEnumerator Defending()
        {
            while (_areAnyOpponents)
            {
                _defensiveWeapon.AttackEnemy();

                yield return _wait;
            }
        }
    }
}
