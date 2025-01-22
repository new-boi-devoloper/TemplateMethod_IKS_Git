using Player;
using UnityEngine;

namespace Strategies
{
    public class DownToUpAttack : IAttackStrategy
    {
        public void PlayAnim(Animator animator)
        {
            animator.SetTrigger(PlayerAnims.DownToUp);
        }
    }
}