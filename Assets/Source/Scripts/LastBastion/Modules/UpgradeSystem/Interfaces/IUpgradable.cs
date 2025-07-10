namespace LastBastion.UpgradeSystem.Interfaces
{
    public interface IUpgradable
    {
        UpgradeLevel Level { get; }

        void Upgrade();
    }
}
