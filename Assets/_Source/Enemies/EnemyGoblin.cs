using UnityEngine;

namespace Enemies
{
    public class EnemyGoblin : AEnemy
    {
        public static readonly int Speed = Animator.StringToHash("Speed");

        public override void Attack()
        {
            Animator.SetTrigger(EnemyAnims.Attack);
        }

        public override void Stop()
        {
            Animator.SetFloat(Speed, 0f);
        }
    }
}