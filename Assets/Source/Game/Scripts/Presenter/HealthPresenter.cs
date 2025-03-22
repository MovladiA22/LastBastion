using LastBastion.Model;
using LastBastion.View.Interface;
using System;

namespace LastBastion.Presenter
{
    public class HealthPresenter
    {
        private readonly Health _health;
        private readonly IHealthView _healthView;

        public HealthPresenter(IHealthView healthView, int maxValue)
        {
            _healthView = healthView ?? throw new ArgumentNullException(nameof(healthView));
            
            _health = new Health(maxValue);
        }

        public int CurrentValue => _health.CurrentValue;

        public void Enable()
        {
            _healthView.OnValueIncreased += _health.Increase;
            _healthView.OnValueDecreased += _health.Decrease;
        }

        public void Disable()
        {
            _healthView.OnValueIncreased -= _health.Increase;
            _healthView.OnValueDecreased -= _health.Decrease;
        }
    }
}
