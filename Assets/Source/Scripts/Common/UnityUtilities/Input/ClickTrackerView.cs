using System;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UnityUtilities.Input
{
    public class ClickTrackerView<T> : ClickTracker<T>
    {
        [SerializeField] private Image _image;

        private Color _defaultColor;
        private Color _newColor = Color.red;

        public event Action OnActivated;

        protected override void Awake()
        {
            base.Awake();

            _defaultColor = _image.color;
            OnActivated?.Invoke();
        }

        public override void Activate()
        {
            base.Activate();

            _image.color = _newColor;
        }

        public override void Deactivate()
        {
            base.Deactivate();

            _image.color = _defaultColor;
        }
    }
}
