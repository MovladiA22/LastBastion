using System;
using System.Linq;
using System.Collections.Generic;
using LastBastion.CombatSystem.Interfaces;

namespace LastBastion.CombatSystem.Logic
{
    public class KeeperOfTriggerdOpponents : IKeeperOpponents
    {
        private List<IDamageable> _opponents;

        public KeeperOfTriggerdOpponents()
        {
            _opponents = new List<IDamageable>();
        }

        public bool IsEmpty => _opponents.Count == 0;

        public void AddOpponent(IDamageable opponent)
        {
            if (opponent == null)
                throw new ArgumentNullException(nameof(opponent));

            opponent.OnHealthIsOver += RemoveOpponent;
            _opponents.Add(opponent);
        }

        public void RemoveOpponent(IDamageable opponent)
        {
            if (_opponents.Contains(opponent) == false)
                return;

            opponent.OnHealthIsOver -= RemoveOpponent;
            _opponents.Remove(opponent);
        }

        public void RemoveAllOpponents()
        {
            foreach (var opponent in _opponents.ToList())
                opponent.OnHealthIsOver -= RemoveOpponent;

            _opponents.Clear();
        }

        public IDamageable GetFirstOpponent() =>
            IsEmpty == false ? _opponents[0] : null;

        public IReadOnlyList<IDamageable> GetAllOpponents() =>
            IsEmpty == false ? _opponents : null;
    }
}
