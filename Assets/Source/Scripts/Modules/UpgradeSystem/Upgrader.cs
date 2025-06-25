using System;
using UnityEngine;

namespace LastBastion.UpgradeSystem
{
    public class Upgrader : MonoBehaviour, IUpgrader
    {
        private const int OneLevel = 1;

        [SerializeField] private int _ultimateUpgradeLevel;

        public IUpgradable Upgradable { get; private set; }
        public Level Level { get; private set; }

        private void Awake()
        {
            Level = new Level(_ultimateUpgradeLevel);

            Level.Decrease(_ultimateUpgradeLevel);
            Level.Increase(OneLevel);
        }

        public virtual void SetUpgradable(IUpgradable upgradable) =>
            Upgradable = upgradable ?? throw new ArgumentNullException(nameof(upgradable));

        public bool TryUpgrade()
        {
            if (Upgradable == null)
                return false;

            if (Level.CurrentValue < Level.MaxValue)
            {
                Level.Increase(OneLevel);
                Upgradable.Upgrade();

                return true;
            }

            return false;
        }

        public bool TryDowngrade()
        {
            if (Upgradable == null)
                return false;

            if (Level.CurrentValue > OneLevel)
            {
                Level.Decrease(OneLevel);
                Upgradable.Upgrade();

                return true;
            }

            return false;
        }
    }
}
