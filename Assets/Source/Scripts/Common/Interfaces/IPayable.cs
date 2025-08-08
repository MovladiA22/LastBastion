using Common.VariableSystem.Interfaces;

namespace Common.Interfaces
{
    public interface IPayable
    {
        IVariable<int> Money { get;}

        bool TryPay(int price);
    }
}
