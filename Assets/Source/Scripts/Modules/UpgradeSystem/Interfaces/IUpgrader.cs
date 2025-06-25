namespace LastBastion.UpgradeSystem
{
    public interface IUpgrader
    {
        IUpgradable Upgradable { get; }

        bool TryUpgrade();
        bool TryDowngrade();
    }
}
