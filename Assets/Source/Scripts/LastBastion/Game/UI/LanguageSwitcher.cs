using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using YG;

namespace LastBastion.Game.UI
{
    internal class LanguageSwitcher : MonoBehaviour
    {
        private readonly Dictionary<int, string> _languages = new()
        {
            {0, "ru"},
            {1, "en" },
            {2, "tr" }
        };

        [SerializeField] private Dropdown _dropdown;

        private void OnEnable()
        {
            _dropdown.onValueChanged.AddListener(SwitchLanguage);
        }

        private void OnDisable()
        {
            _dropdown.onValueChanged.RemoveListener(SwitchLanguage);
        }

        private void SwitchLanguage(int value)
        {
            if (value >= _languages.Count)
                throw new ArgumentOutOfRangeException("value");

            YandexGame.SwitchLanguage(_languages[value]);
        }
    }
}
