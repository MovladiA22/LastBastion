using LastBastion.CombatSystem.Interfaces;
using Common.VariableSystem.Interfaces;
using Common.UnityUtilities.Coroutines;
using Common.UnityUtilities.Behaviors;
using LastBastion.CombatSystem.Logic;
using LastBastion.CombatSystem;
using System.Collections;
using UnityEngine;
using System;

namespace LastBastion.Bases
{
    public abstract class Base : ManagedBehavior, IDamageable
    {
        [SerializeField, Min(1)] private int _healthValue;
        [SerializeField] private DamageReaction _damageReaction;

        private CoroutineRunner _workCoroutine;

        public event Action OnDestroid;
        public event Action<IDamageable> OnHealthIsOver;

        [field: SerializeField] protected BaseGarrison Garrison { get; private set; }

        public IVariableInt IHealth => Health;
        protected Health Health { get; private set; }

        public override void Init()
        {
            Health = new Health(_healthValue);
            _workCoroutine = new CoroutineRunner(this, Working);

            Garrison.Init();
        }

        public override void Activate()
        {
            base.Activate();

            Health.ReplenishFullValue();
            Garrison.Activate();

            _workCoroutine.Run();
        }

        public override void Deactivate()
        {
            base .Deactivate();

            Garrison.Deactivate();
            _workCoroutine.Cancel();
        }

        public void TakeDamage(int amount)
        {
            _damageReaction.ActivateEffect();

            Health.Decrease(amount);

            if (Health.CurrentValue == 0)
                Collapse();
        }

        protected virtual void Work() =>
            Garrison.Work();

        protected void Collapse() =>
            OnDestroid?.Invoke();

        private IEnumerator Working()
        {
            while (IsActivated)
            {
                Work();

                yield return null;
            }
        }
    }
}
