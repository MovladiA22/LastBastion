using LastBastion.View.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class ArrowAttackTrigger : EnemyTrigger
    {
        [SerializeField] private Arrow _arrow;

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Arrow arrow) && arrow == _arrow)
                arrow.InvokeReleaseEvent();
        }
    }
}
