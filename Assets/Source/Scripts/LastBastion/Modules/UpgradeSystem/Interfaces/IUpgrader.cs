namespace LastBastion.UpgradeSystem.Interfaces
{
    public interface IUpgrader
    {
        IUpgradable Upgradable { get; }

        bool TryUpgrade();
        bool TryDowngrade();
    }
}
