using LastBastion.Game.Menu;
using Common.UI.Input;
using UnityEngine;

namespace LastBastion.Game
{
    internal class GameRunner : MonoBehaviour
    {
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private ButtonClickHandler _gameStartButton;
        [SerializeField] private SettingsPanel _settingsMenu;
        [SerializeField] private GameProcessor _gameProcessor;

        private void Awake()
        {
            _mainMenu.Init();
        }

        private void OnEnable()
        {
            _gameProcessor.OnGameOver += OnEndGame;
            _gameStartButton.OnClicked += OnStartGame;
        }

        private void Start()
        {
            _mainMenu.Activate();
            _settingsMenu.Activate();
        }

        private void OnDisable()
        {
            _gameProcessor.OnGameOver += OnEndGame;
            _gameStartButton.OnClicked -= OnStartGame;
        }

        private void OnStartGame()
        {
            _mainMenu.Deactivate();
            _settingsMenu.Deactivate();
            _gameProcessor.StartGame();
        }

        private void OnEndGame()
        {
            _mainMenu.Activate();
            _settingsMenu.Activate();
        }
    }
}
