using LastBastion.Model;
using LastBastion.View.Interface;
using System;
using UnityEngine;

namespace LastBastion.Presenter
{
    public class TargetMoverPresenter
    {
        private readonly TargetMover _model;
        private readonly IMovable _view;

        public TargetMoverPresenter(IMovable movable, float speed, float stoppingDistance)
        {
            _view = movable ?? throw new ArgumentNullException(nameof(movable));
            _model = new TargetMover(speed, stoppingDistance);
        }

        public void Enable()
        {
            _view.OnMoved += MoveToTargetAlongX;
        }

        public void Disable()
        {
            _view.OnMoved -= MoveToTargetAlongX;
        }

        public void MoveToTargetAlongX()
        {
            if (_model.IsReachedTarget(new Vector2(_view.TargetPosition.x, _view.CurrentPosition.y), _view.CurrentPosition) == false)
            {
                _view.UpdatePosition(_model.MoveToTarget(new Vector2(_view.TargetPosition.x, _view.CurrentPosition.y), _view.CurrentPosition));
            }
            else
            {
                _view.InvokeReachedEvent();
            }
        }
    }
}
