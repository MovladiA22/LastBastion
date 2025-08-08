using LastBastion.Game.UI;
using UnityEngine.UI;
using UnityEngine;

namespace LastBastion.Game.View
{
    internal class GameInfoRenderer : MonoBehaviour
    {
        [SerializeField] private Text _textField;
        [SerializeField] private GameInfoButton[] _gameInfoButtons;

        private string _defaultText;

        private void OnEnable()
        {
            _defaultText = _textField.text;

            foreach (var button in _gameInfoButtons)
                button.OnClicked += RenderGameInfo;
        }

        private void OnDisable()
        {
            _textField.text = _defaultText;

            foreach (var button in _gameInfoButtons)
                button.OnClicked -= RenderGameInfo;
        }

        private void RenderGameInfo(string text) =>
            _textField.text = text;
    }
}
