using UnityUtilities.Coroutines;
using LastBastion.CombatSystem;
using Common.VariableSystem;
using System.Collections;
using Common.Interfaces;
using UnityEngine;
using System;

namespace LastBastion.Bases
{
    [RequireComponent(typeof(DamageReaction))]
    public abstract class Base : ManagedBehavior, IDamageable
    {
        [SerializeField, Min(1)] private int _healthValue;

        private DamageReaction _damageReaction;
        private CoroutineRunner _workCoroutine;

        public event Action OnDestroid;
        public event Action<IDamageable> OnHealthIsOver;

        [field: SerializeField] protected BaseGarrison Garrison { get; private set; }

        protected Health Health { get; private set; }
        public IVariableInt IHealth => Health;

        public override void Init()
        {
            Health = new Health(_healthValue);
            _workCoroutine = new CoroutineRunner(this, Working);
            _damageReaction = GetComponent<DamageReaction>();

            Garrison.Init();
        }

        public void TakeDamage(int amount)
        {
            if (IsActivated == false)
                return;

            ReactToDamage();

            Health.Decrease(amount);

            if (Health.CurrentValue == 0)
                HandleDestruction();
        }

        public void ReactToDamage() =>
            _damageReaction.ActivateEffect();

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

        protected virtual void HandleDestruction() =>
            OnDestroid?.Invoke();

        protected virtual void Work()
        {
            Garrison.Work();
        }

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
