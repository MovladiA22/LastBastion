using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    internal class EnemyBaseCommander : MonoBehaviour
    {
        [SerializeField] private List<EnemyBase> _bases;
        [SerializeField] private CoroutineView _spawnCoroutine;

        private EnemyBase _activeBase;

        public IReadOnlyList<EnemyBase> EnemyBases => _bases;

        private void Awake()
        {
            foreach (var enemyBase in _bases)
                enemyBase.gameObject.SetActive(false);

            _spawnCoroutine.CreateCoroutine(SpawningUnit());
        }

        public void Activate()
        {
            if (_activeBase != null)
            {
                _spawnCoroutine.Cancel();
                _bases.Remove(_activeBase);
                Destroy(_activeBase.gameObject);
            }

            if (_bases.Count > 0)
            {
                _activeBase = _bases[0];
                _activeBase.gameObject.SetActive(true);
                _spawnCoroutine.Run();
            }
        }

        private IEnumerator SpawningUnit()
        {
            var _wait = new WaitForSeconds(_activeBase.SpawnDelay);

            while (_bases.Count > 0)
            {
                _activeBase.Spawn();

                yield return _wait;
            }
        }
    }
}
