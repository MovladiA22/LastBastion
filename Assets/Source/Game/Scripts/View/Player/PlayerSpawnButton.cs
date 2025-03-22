using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LastBastion.View
{
    public class PlayerSpawnButton : MonoBehaviour
    {
        [SerializeField] private PlayerBase _playerBase;
        [SerializeField] private Button _button;
        [SerializeField] private int _spawnerIndex;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnSpawn);
        }

        private void OnDisable()
        {
            _button?.onClick.RemoveListener(OnSpawn);
        }

        private void OnSpawn()
        {
            _playerBase.SpawnUnit(_spawnerIndex);
        }
    }
}
