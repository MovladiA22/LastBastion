using Common.UnityUtilities.Coroutines;
using UnityEngine;

namespace LastBastion.CombatSystem
{
    public class DamageReaction : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private float _duration = 0.2f;
        [SerializeField] private float _transparency = 0.5f;

        private Color _originalColor;
        private CoroutineTimer _deactivateTimer;

        private void Awake()
        {
            _deactivateTimer = new CoroutineTimer(this, _duration, DeactivateEffect);
            _originalColor = _renderer.color;
        }

        private void OnEnable()
        {
            DeactivateEffect();
        }

        public void ActivateEffect()
        {
            if (_deactivateTimer.IsTimeUp)
            {
                Color newColor = _originalColor;
                newColor.a = _transparency;

                _renderer.color = newColor;
                _deactivateTimer.Run();
            }
        }

        private void DeactivateEffect()
        {
            _deactivateTimer.Stop();
            _renderer.color = _originalColor;
        }
    }
}
