using Common.Interfaces;
using LastBastion.Bases;
using UnityEngine;

namespace LastBastion.Game
{
    internal class BattlePreparationInfoView : ManagedBehavior
    {
        [SerializeField] private CurrentLevelRenderer _currentLevelRenderer;
        [SerializeField] private PlayerBaseMoneyRenderer _playerBaseMoneyRenderer;
        [SerializeField] private PlayerBaseProvisionsRenderer _playerBaseProvisionsRenderer;
        [SerializeField] private PlayerBaseHealthRenderer _playerBaseHealthRenderer;
        [SerializeField] private UnitsCountRenderer _unitsCountRenderer;
        [SerializeField] private DefensiveWeaponsCountRenderer _defensiveWeaponsCountRenderer;
        [SerializeField] private BlessingsCountRenderer _blessingsCountRenderer;

        public override void Init()
        {
            _currentLevelRenderer.Init();
            _playerBaseHealthRenderer.Init();
            _playerBaseMoneyRenderer.Init();
            _playerBaseProvisionsRenderer.Init();
            _defensiveWeaponsCountRenderer.Init();
            _unitsCountRenderer.Init();
            _blessingsCountRenderer.Init();
        }

        public override void Activate()
        {
            base.Activate();

            _playerBaseHealthRenderer.Activate();
            _playerBaseMoneyRenderer.Activate();
            _playerBaseProvisionsRenderer.Activate();
            _unitsCountRenderer.Activate();
            _defensiveWeaponsCountRenderer.Activate();
            _blessingsCountRenderer.Activate();

            _currentLevelRenderer.RenderLevel();
        }

        public override void Deactivate()
        {
            base.Deactivate();

            _playerBaseHealthRenderer.Deactivate();
            _playerBaseProvisionsRenderer.Deactivate();
            _playerBaseMoneyRenderer.Deactivate();
            _unitsCountRenderer.Deactivate();
            _defensiveWeaponsCountRenderer.Deactivate();
            _blessingsCountRenderer.Deactivate();
        }
    }
}
