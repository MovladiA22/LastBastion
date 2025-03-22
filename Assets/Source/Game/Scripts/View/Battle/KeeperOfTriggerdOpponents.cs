using LastBastion.View.Interface;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LastBastion.View
{
    internal class KeeperOfTriggerdOpponents : MonoBehaviour
    {
        private List<IDamageable> _opponents = new();

        public bool TryGetOpponent(out IDamageable opponent)
        {
            opponent = null;

            if (_opponents.Count == 0)
                return false;

            opponent = _opponents[0];
            return true;
        }

        public void OnAddOpponent(IDamageable opponent)
        {
            if (opponent == null)
                throw new ArgumentNullException(nameof(opponent));

            opponent.OnValueIsOver += OnRemoveOpponent;
            _opponents.Add(opponent);
        }

        public void OnRemoveOpponent(IDamageable opponent)
        {
            if (opponent == null)
                throw new ArgumentNullException(nameof(opponent));

            opponent.OnValueIsOver -= OnRemoveOpponent;
            _opponents.Remove(opponent);
        }
    }
}
