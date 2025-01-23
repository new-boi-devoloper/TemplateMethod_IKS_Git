using Enemies;
using UI;

namespace Main
{
    public class EnemySwitcher
    {
        private readonly ClientUI _clientUI;
        private readonly AEnemy[] _enemies;

        public EnemySwitcher(ClientUI clientUI, params AEnemy[] enemies)
        {
            _clientUI = clientUI;
            _enemies = enemies;

            _clientUI.OnAttackChanged += SwitchEnemy;
        }

        public void SwitchEnemy(AttackType attackType)
        {
            DeactivateEnemies();

            switch (attackType)
            {
                case AttackType.UpToDownAttackButton:
                    ActivateEnemy<EnemyMushroom>();
                    break;
                case AttackType.DownToUpAttackButton:
                    ActivateEnemy<EnemySkeleton>();
                    break;
                case AttackType.NoScopeHardProAttack:
                    ActivateEnemy<EnemyGoblin>();
                    break;
            }
        }

        private void ActivateEnemy<T>() where T : AEnemy
        {
            foreach (var enemy in _enemies)
                if (enemy is T)
                {
                    enemy.gameObject.SetActive(true);
                    break;
                }
        }

        private void DeactivateEnemies()
        {
            foreach (var enemy in _enemies)
            {
                enemy.Stop();
                enemy.gameObject.SetActive(false);
            }
        }
    }
}