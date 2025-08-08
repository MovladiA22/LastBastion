using LastBastion.Game.Menu;
using LastBastion.Game.UI;
using Common.UI.Input;
using UnityEngine;
using YG;

namespace LastBastion.Game
{
    internal class GameRunner : MonoBehaviour
    {
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private ButtonClickHandler _gameStartButton;
        [SerializeField] private SettingsPanel _settingsMenu;
        [SerializeField] private GameProcessor _gameProcessor;
        [SerializeField] private GameObject _victoriousPanel;

        private void Awake()
        {
            _victoriousPanel.SetActive(false);
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

            YandexGame.GameReadyAPI();
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

        private void OnEndGame(bool isWon)
        {
            if (isWon)
                _victoriousPanel.SetActive(true);

            _mainMenu.Activate();
            _settingsMenu.Activate();
        }
    }
}
