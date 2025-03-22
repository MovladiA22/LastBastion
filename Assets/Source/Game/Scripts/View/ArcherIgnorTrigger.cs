using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class ArcherIgnorTrigger : UnitTrigger
    {
        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Archer>(out _))
                return;

            base.OnTriggerEnter2D(collision);
        }

        protected override void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Archer>(out _))
                return;

            base.OnTriggerExit2D(collision);
        }
    }
}
