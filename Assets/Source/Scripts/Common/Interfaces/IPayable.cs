using Common.VariableSystem.Interfaces;

namespace Common.Interfaces
{
    public interface IPayable
    {
        IVariableInt Money { get;}

        bool TryPay(int price);
    }
}
