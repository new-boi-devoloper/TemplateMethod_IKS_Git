using Player;
using UnityEngine;

namespace Strategies
{
    public class NoScopeHardProAttack : IAttackStrategy
    {
        public void PlayAnim(Animator animator)
        {
            animator.SetTrigger(PlayerAnims.NoScopeHard);
        }
    }
}