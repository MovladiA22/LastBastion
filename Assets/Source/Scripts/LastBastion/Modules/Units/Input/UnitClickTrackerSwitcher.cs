using UnityEngine;

namespace LastBastion.Units.Input
{
    internal class UnitClickTrackerSwitcher : MonoBehaviour
    {
        [SerializeField] private PlayerUnitClickTracker _playerUnitClickTracker;
        [SerializeField] private EnemyUnitClickTracker _enemyUnitClickTracker;

        private void OnEnable()
        {
            _playerUnitClickTracker.OnActivated += SwitchToPlayerTracker;
            _enemyUnitClickTracker.OnActivated += SwitchToEnemyTracker;
        }

        private void OnDisable()
        {
            _playerUnitClickTracker.OnActivated -= SwitchToPlayerTracker;
            _enemyUnitClickTracker.OnActivated -= SwitchToEnemyTracker;
        }

        private void SwitchToPlayerTracker()
        {
            if (_enemyUnitClickTracker.IsActivated)
                _enemyUnitClickTracker.Deactivate();
        }

        private void SwitchToEnemyTracker()
        {
            if (_playerUnitClickTracker.IsActivated)
                _playerUnitClickTracker.Deactivate();
        }
    }
}
