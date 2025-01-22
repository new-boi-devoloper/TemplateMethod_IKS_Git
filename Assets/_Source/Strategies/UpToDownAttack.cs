using Player;
using UnityEngine;

namespace Strategies
{
    public class UpToDownAttack : IAttackStrategy
    {
        public void PlayAnim(Animator animator)
        {
            animator.SetTrigger(PlayerAnims.UpToDown);
        }
    }
}