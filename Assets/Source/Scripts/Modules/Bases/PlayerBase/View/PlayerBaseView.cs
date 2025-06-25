using Common.Interfaces;
using Common.UI.View;
using UnityEngine;

namespace LastBastion.Bases
{
    public class PlayerBaseView : ManagedBehavior
    {
        [SerializeField] private PlayerBase _playerBase;
        [SerializeField] private VariableIntTextRenderer _moneyRenderer;
        [SerializeField] private ProvisionsView _provisionsView;

        public override void Init()
        {
            _moneyRenderer.SetVariable(_playerBase.Money);
            _provisionsView.SetProvisions(_playerBase.Provisions);

            _provisionsView.Init();
        }

        public override void Activate()
        {
            base.Activate();

            _moneyRenderer.Activate();
            _provisionsView.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();

            _moneyRenderer.Deactivate();
            _provisionsView.Deactivate();
        }
    }
}
