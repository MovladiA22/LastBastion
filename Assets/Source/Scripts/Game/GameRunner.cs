using Common.UI.Input;
using UnityEngine;

namespace LastBastion.Game
{
    internal class GameRunner : MonoBehaviour
    {
        [SerializeField] private GameRunnerView _view;
        [SerializeField] private ButtonClickHandler _gameStartButton;
        [SerializeField] private SettingsMenu _settingsMenu;
        [SerializeField] private GameProcessor _gameProcessor;

        private void Awake()
        {
            _view.Init();
        }

        private void OnEnable()
        {
            _gameProcessor.OnGameOver += OnEndGame;
            _gameStartButton.OnClicked += OnStartGame;
        }

        private void Start()
        {
            _view.Activate();
            _settingsMenu.Activate();
        }

        private void OnDisable()
        {
            _gameProcessor.OnGameOver += OnEndGame;
            _gameStartButton.OnClicked -= OnStartGame;
        }

        private void OnStartGame()
        {
            _view.Deactivate();
            _settingsMenu.Deactivate();
            _gameProcessor.StartGame();
        }

        private void OnEndGame()
        {
            _view.Activate();
            _settingsMenu.Activate();
        }
    }
}
