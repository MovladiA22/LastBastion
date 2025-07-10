using LastBastion.CombatSystem;
using UnityEngine;
using System;

namespace LastBastion.Units.PlayerUnits
{
    public class Rogue : PlayerUnit
    {
        private readonly float _transparency = 0.5f;
        private SpriteRenderer _renderer;
        private Collider2D _collider;
        private Color _originalColor;
        private Color _changedColor;

        protected override void Awake()
        {
            base.Awake();

            _renderer = GetComponent<SpriteRenderer>() ?? throw new ArgumentNullException(nameof(_renderer));
            _collider = GetComponent<Collider2D>() ?? throw new ArgumentNullException(nameof(_collider));

            _originalColor = _renderer.color;
            _changedColor = _renderer.color;
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            AttackSystem.OnAttacked += DeactivateStealth;

            ActivateStealth();
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            AttackSystem.OnAttacked -= DeactivateStealth;

            DeactivateStealth();
        }

        private void ActivateStealth()
        {
            _collider.enabled = false;
            _changedColor.a = _transparency;
            _renderer.color = _changedColor;
        }

        private void DeactivateStealth()
        {
            if (_collider.enabled)
                return;

            _collider.enabled = true;
            _renderer.color = _originalColor;
        }
    }
}
