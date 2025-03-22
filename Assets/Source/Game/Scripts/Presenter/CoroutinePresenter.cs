using LastBastion.Model;
using LastBastion.View.Interface;
using System;
using System.Collections;
using UnityEngine;

namespace LastBastion.Presenter
{
    public class CoroutinePresenter
    {
        private readonly CoroutineModel _coroutineModel;
        private readonly ICoroutineView _coroutineView;

        public CoroutinePresenter(IEnumerator coroutine, ICoroutineView coroutineView, MonoBehaviour monoBehaviour)
        {
            _coroutineView = coroutineView ?? throw new ArgumentNullException(nameof(coroutineView));
            _coroutineModel = new CoroutineModel(monoBehaviour, coroutine);
        }

        public void Enable()
        {
            _coroutineView.OnStarted += _coroutineModel.Start;
            _coroutineView.OnStopped += _coroutineModel.Stop;
        }

        public void Disable()
        {
            _coroutineView.OnStarted -= _coroutineModel.Start;
            _coroutineView.OnStopped -= _coroutineModel.Stop;
        }
    }
}
