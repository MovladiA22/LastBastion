using UnityEngine;
using Common.UI.Output;
using Common.UnityUtilities.Behaviors;
using LastBastion.BlessingSystem.View;
using LastBastion.DefensiveSystem.View;

namespace LastBastion.Bases.PlayerBase.Output
{
    public class PlayerBaseInfoRenderer : ManagedBehavior
    {
        [SerializeField] private PlayerBase _playerBase;
        [SerializeField] private VariableIntTextRenderer _healthRenderer;
        [SerializeField] private VariableIntTextRenderer _moneyRenderer;
        [SerializeField] private PlayerUnitsCountRenderer _unitsCountRenderer;
        [SerializeField] private BlessingsCountRenderer _blessingsCountRenderer;
        [SerializeField] private DefensiveWeaponsCountRenderer _defensiveWeaponsCountRenderer;

        public override void Init()
        {
            _healthRenderer.SetVariable(_playerBase.IHealth);
            _moneyRenderer.SetVariable(_playerBase.Money);
            _blessingsCountRenderer.Init();
            _defensiveWeaponsCountRenderer.Init();

            _unitsCountRenderer.Init();
        }

        public override void Activate()
        {
            base.Activate();

            _healthRenderer.Activate();
            _moneyRenderer.Activate();
            _unitsCountRenderer.Activate();
            _blessingsCountRenderer.Activate();
            _defensiveWeaponsCountRenderer.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();

            _healthRenderer.Deactivate();
            _moneyRenderer.Deactivate();
            _unitsCountRenderer.Deactivate();
            _blessingsCountRenderer.Deactivate();
            _defensiveWeaponsCountRenderer.Deactivate();
        }
    }
}
