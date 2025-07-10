using UnityEngine;
using Common.UI.Output;
using Common.UnityUtilities.Behaviors;
using LastBastion.BlessingSystem.View;
using LastBastion.DefensiveSystem.View;

namespace LastBastion.Bases.PlayerBase.View
{
    public class PlayerBaseView : ManagedBehavior
    {
        [SerializeField] private PlayerBase _playerBase;
        [SerializeField] private PlayerGarrisonView _playerGarrisonView;
        [SerializeField] private DefensiveSystemView _defensiveSystemView;
        [SerializeField] private BlessingActivatorView _blessingActivatorView;
        [SerializeField] private VariableIntTextRenderer _moneyRenderer;
        [SerializeField] private BarRenderer _provisionsView;

        public override void Init()
        {
            _moneyRenderer.SetVariable(_playerBase.Money);
            _provisionsView.SetVariable(_playerBase.Provisions);

            _blessingActivatorView.Init();
        }

        public override void Activate()
        {
            base.Activate();

            _playerGarrisonView.Activate();
            _defensiveSystemView.Activate();
            _blessingActivatorView.Activate();
            _moneyRenderer.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();

            _playerGarrisonView.Deactivate();
            _defensiveSystemView.Deactivate();
            _blessingActivatorView.Deactivate();
            _moneyRenderer.Deactivate();
        }
    }
}
