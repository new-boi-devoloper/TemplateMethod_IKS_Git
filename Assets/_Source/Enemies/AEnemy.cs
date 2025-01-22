using UnityEngine;

namespace Enemies
{
    public abstract class AEnemy : MonoBehaviour
    {
        protected Animator animator;

        protected virtual void Start()
        {
            animator = GetComponent<Animator>();
        }

        public abstract void Attack();
        public abstract void Stop();
    }
}