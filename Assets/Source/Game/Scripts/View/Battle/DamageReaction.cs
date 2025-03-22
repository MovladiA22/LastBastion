using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class DamageReaction : MonoBehaviour
    {
        [SerializeField] private float _duration = 0.2f;
        [SerializeField] private float _transparency = 0.5f;
        [SerializeField] private float _brightnessmultiplier = 1.5f;

        private SpriteRenderer _renderer;
        private Color _originalColor;
        private YieldInstruction _wait;
        private bool _isActivate;

        private void Awake()
        {
            if (TryGetComponent(out SpriteRenderer renderer))
                _renderer = renderer;
            else
                throw new ArgumentNullException(nameof(renderer));

            _originalColor = _renderer.color;
            _wait = new WaitForSeconds(_duration);
        }

        private void OnEnable()
        {
            _renderer.color = _originalColor;
            _isActivate = false;
        }

        public void ActivateEffect()
        {
            if (_isActivate == false)
            {
                StartCoroutine(FlashEffect());
                _isActivate = true;
            }
        }

        private IEnumerator FlashEffect()
        {
            Color newColor = _originalColor * _brightnessmultiplier;
            newColor.a = _transparency;

            _renderer.color = newColor;

            yield return _wait;

            _renderer.color = _originalColor;
            _isActivate = false;
        }
    }
}
