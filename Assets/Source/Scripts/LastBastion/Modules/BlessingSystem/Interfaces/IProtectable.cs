namespace LastBastion.BlessingSystem.Interfaces
{
    public interface IProtectable : IDivineIntervention
    {
        bool IsInvulnerable { get; set; }
    }
}
