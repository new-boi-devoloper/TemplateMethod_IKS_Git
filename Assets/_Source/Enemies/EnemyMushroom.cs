using Player;
using Zenject;

namespace Enemies
{
    public class EnemyMushroom : AEnemy
    {
        private AttackPerformer _playerAttackPerformer;

        private void OnDestroy()
        {
            _playerAttackPerformer.OnAttackPerformed -= Attack;
        }

        [Inject]
        public void Construct(AttackPerformer attackPerformer)
        {
            _playerAttackPerformer = attackPerformer;
            _playerAttackPerformer.OnAttackPerformed += Attack;
        }

        public override void Attack()
        {
            Animator.SetTrigger(EnemyAnims.Attack);
        }

        public override void Stop()
        {
            Animator.SetFloat(EnemyAnims.Speed, 0f);
        }
    }
}