namespace Enemies
{
    public class EnemyGoblin : AEnemy
    {
        public override void Attack()
        {
            animator.SetTrigger(EnemyAnims.Attack);
        }

        public override void Stop()
        {
            animator.SetTrigger(EnemyAnims.Idle);
        }
    }
}