using System;

namespace LastBastion.UpgradeSystem
{
    public interface IUpgradable
    {
        Level Level { get; }

        void Upgrade();
    }
}
