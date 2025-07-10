namespace Common.UnityUtilities.Behaviors
{
    public interface IActivable
    {
        bool IsActivated { get; }

        void Activate();
        void Deactivate();
    }
}
