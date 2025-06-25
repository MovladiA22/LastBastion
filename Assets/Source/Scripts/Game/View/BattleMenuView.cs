using Common.VariableSystem;
using LastBastion.Bases;
using Common.UI.View;
using UnityEngine;
using Common.Audio;

namespace LastBastion.Game
{
    internal class BattleMenuView : UIMenu
    {
        [SerializeField] private BarRenderer _playerBar;
        [SerializeField] private BarRenderer _enemyBar;
        [SerializeField] private PlayerBaseView _playerBaseView;
        [SerializeField] private ChurchView _churchView;
        [SerializeField] private DefensiveSystemView _defensiveSystemView;
        [SerializeField] private PlayerGarrisonView _playerGarrisonView;
        [SerializeField] private MusicRunner _combatBackground;

        public override void Init()
        {
            _playerBaseView.Init();
            _churchView.Init();
            _defensiveSystemView.Init();
            _playerGarrisonView.Init();

            base.Init();
        }

        public override void Activate()
        {
            base.Activate();

            _combatBackground.RunAudio();
            _playerBaseView.Activate();
            _churchView.Activate();
            _defensiveSystemView.Activate();
            _playerGarrisonView.Activate();

            _defensiveSystemView.Init();
            _playerGarrisonView.Init();
        }

        public override void Deactivate()
        {
            if (IsActivated == false)
                return;

            _playerBaseView.Deactivate();
            _churchView.Deactivate();
            _defensiveSystemView.Deactivate();
            _playerGarrisonView.Deactivate();
            _combatBackground.StopAudio();

            base.Deactivate();
        }

        public void SetHealthBar(IVariableInt playerHealth, IVariableInt enemyHealth)
        {
            _playerBar.Init(playerHealth);
            _enemyBar.Init(enemyHealth);
        }
    }
}
