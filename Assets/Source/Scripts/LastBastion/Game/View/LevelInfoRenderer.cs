using LastBastion.Bases.PlayerBase.Output;
using Common.UnityUtilities.Behaviors;
using UnityEngine;

namespace LastBastion.Game.View
{
    internal class LevelInfoRenderer : ManagedBehavior
    {
        [SerializeField] private CurrentLevelRenderer _currentLevelRenderer;
        [SerializeField] private PlayerBaseInfoRenderer _playerBaseInfoRenderer;

        public override void Init()
        {
            _playerBaseInfoRenderer.Init();
        }

        public override void Activate()
        {
            base.Activate();

            _playerBaseInfoRenderer.Activate();
            _currentLevelRenderer.RenderLevel();
        }

        public override void Deactivate()
        {
            base.Deactivate();

            _playerBaseInfoRenderer.Deactivate();
        }
    }
}
