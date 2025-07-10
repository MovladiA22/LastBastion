using UnityEngine;
using UnityEngine.UI;

namespace Common.UI.Output
{
    public class TextRenderer : MonoBehaviour
    {
        [SerializeField] private Text _textField;

        public virtual void Render(string text)
        {
            _textField.text = text;
        }
    }
}
