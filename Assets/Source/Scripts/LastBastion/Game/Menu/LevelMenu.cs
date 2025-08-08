using LastBastion.Bases.PlayerBase.View;
using Common.VariableSystem.Interfaces;
using Common.VariableSystem;
using Common.UI.Output;
using Common.Audio;
using UnityEngine;
using Common.UI;

namespace LastBastion.Game.Menu
{
    internal class LevelMenu : UIMenu
    {
        [SerializeField] private BarRenderer _playerBar;
        [SerializeField] private BarRenderer _enemyBar;
        [SerializeField] private PlayerBaseView _playerBaseView;
        [SerializeField] private MusicRunner _combatBackground;

        public override void Init()
        {
            _playerBaseView.Init();

            base.Init();
        }

        public override void Activate()
        {
            base.Activate();

            _combatBackground.RunAudio();
            _playerBaseView.Activate();
        }

        public override void Deactivate()
        {
            if (IsActivated == false)
                return;

            _playerBaseView.Deactivate();
            _combatBackground.StopAudio();

            base.Deactivate();
        }

        public void SetHealthBar(IVariable<int> playerHealth, IVariable<int> enemyHealth)
        {
            _playerBar.SetVariable(new IntVariableToFloatConverter(playerHealth));
            _enemyBar.SetVariable(new IntVariableToFloatConverter(enemyHealth));
        }
    }
}
