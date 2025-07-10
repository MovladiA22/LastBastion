using LastBastion.UnitSpawners.PlayerSpawners;
using Common.UI.View;
using UnityEngine.UI;
using UnityEngine;

namespace LastBastion.UnitSpawners.View
{
    internal class PlayerSpawnButton : AccessCostableLockableButton
    {
        [SerializeField] private PlayerUnitSpawner _spawner;
        [SerializeField] private Text _priceTextField;

        public override int AccessLevel => _spawner.AccessLevel;
        public override int Price => _spawner.Price;

        private void Awake()
        {
            _priceTextField.text = _spawner.Price.ToString();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            _spawner.SpawnZone.OnEntered += InvokeLockEvent;
            _spawner.SpawnZone.OnExited += InvokeUnlockEvent;

            _spawner.OnActivated += InvokeLockEvent;
            _spawner.OnDeactivated += InvokeUnlockEvent;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _spawner.SpawnZone.OnEntered -= InvokeLockEvent;
            _spawner.SpawnZone.OnExited -= InvokeUnlockEvent;

            _spawner.OnActivated -= InvokeLockEvent;
            _spawner.OnDeactivated -= InvokeUnlockEvent;
        }

        public override void UnlockButton()
        {
            if (_spawner.SpawnZone.IsFree)
                base.UnlockButton();
        }

        protected override void InvokeClickEvent(int eventData)
        {
            eventData = _spawner.Index;

            base.InvokeClickEvent(eventData);
        }
    }
}
