using Common.UI.Input;
using UnityEngine;
using YG;

namespace LastBastion.Game.UI
{
    internal class GameInfoButton : ButtonClickHandler<string>
    {
        private const string RuLang = "ru";
        private const string EnLang = "en";
        private const string TrLang = "tr";

        [SerializeField, Multiline] private string _ruGameInfo;
        [SerializeField, Multiline] private string _enGameInfo;
        [SerializeField, Multiline] private string _trGameInfo;

        protected override void InvokeClickEvent(string eventData)
        {
            switch (YandexGame.lang)
            {
                case RuLang:
                    eventData = _ruGameInfo;
                    break;

                case EnLang:
                    eventData = _enGameInfo;
                    break;

                case TrLang:
                    eventData = _trGameInfo;
                    break;
            }

            base.InvokeClickEvent(eventData);
        }
    }
}
