using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class GameProcess : MonoBehaviour
    {
        [SerializeField] private PlayerBase _playerBase;
        [SerializeField] private EnemyBaseCommander _enemyBaseActivator;

        public event Action OnGameIsWon;
        public event Action OnGameIsLost;

        private void OnEnable()
        {
            _playerBase.OnDestroyed += OnHandleDefeat;

            foreach (var enemyBase in _enemyBaseActivator.EnemyBases)
                enemyBase.OnDestroyed += OnSwitchEnemyBase;
        }

        private void Start()
        {
            _enemyBaseActivator.Activate();
        }

        private void OnSwitchEnemyBase()
        {
            _enemyBaseActivator.EnemyBases[0].OnDestroyed -= OnSwitchEnemyBase;
            _enemyBaseActivator.Activate();

            if (_enemyBaseActivator.EnemyBases.Count == 0)
                HandleVictory();
        }

        private void OnHandleDefeat()
        {
            Destroy(_playerBase.gameObject);
            Debug.Log("Lose");
            OnGameIsLost?.Invoke();
        }

        private void HandleVictory()
        {
            Debug.Log("Win");
            OnGameIsWon?.Invoke();
        }
    }
}
