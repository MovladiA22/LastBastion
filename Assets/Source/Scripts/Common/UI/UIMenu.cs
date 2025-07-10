using Common.UnityUtilities.Behaviors;
using UnityEngine;

namespace Common.UI
{
    public abstract class UIMenu : MonoBehaviour, IActivable, IInitializable
    {
        [SerializeField] private Canvas _canvas;

        public bool IsActivated { get; private set; } = false;

        public virtual void Init()
        {
            _canvas.gameObject.SetActive(false);
        }

        public virtual void Activate()
        {
            if (IsActivated)
                return;

            IsActivated = true;
            _canvas.gameObject.SetActive(true);
        }

        public virtual void Deactivate()
        {
            _canvas.gameObject.SetActive(false);

            IsActivated = false;
        }
    }
}
