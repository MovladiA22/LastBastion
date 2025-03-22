using LastBastion.View.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class Rogue : Unit, IPlayer
    {
        private SpriteRenderer _renderer;
        private Collider2D _collider;
        private Color _originalColor;
        private Color _changedColor;
        private float _transparency = 0.5f;

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

            ActivateStealth();
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            DeactivateStealth();
        }

        public override void TryMove()
        {
            if (_collider.enabled == false)
                OnHandleUnitCollision(false);

            base.TryMove();
        }

        protected override void Attack(IDamageable opponent)
        {
            if (_collider.enabled)
                base.Attack(opponent);
        }

        protected override void OnHandleTargetReached()
        {
            base.OnHandleTargetReached();

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
            _collider.enabled = true;

            _renderer.color = _originalColor;
        }
    }
}
