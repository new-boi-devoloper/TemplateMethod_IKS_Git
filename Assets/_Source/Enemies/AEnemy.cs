using UnityEngine;

namespace Enemies
{
    public abstract class AEnemy : MonoBehaviour
    {
        protected Animator Animator;

        protected virtual void Start()
        {
            Animator = GetComponent<Animator>();
        }

        public abstract void Attack();
        public abstract void Stop();
    }
}