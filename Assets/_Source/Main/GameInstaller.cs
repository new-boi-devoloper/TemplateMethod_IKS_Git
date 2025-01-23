using System;
using Enemies;
using Player;
using Strategies;
using UI;
using UnityEngine;
using Zenject;

namespace Main
{
    public class GameInstaller : MonoInstaller
    {
        [field: SerializeField] private ClientUI clientUI;
        [field: SerializeField] private PlayerBoy playerBoy;
        [field: SerializeField] private InputListener inputListener;

        [field: Header("Enemies")] [field: SerializeField]
        private EnemySkeleton enemySkeleton;

        [field: SerializeField] private EnemyMushroom enemyMushroom;
        [field: SerializeField] private EnemyGoblin enemyGoblin;

        public override void InstallBindings()
        {
            Container.Bind<ClientUI>().FromInstance(clientUI).AsSingle().Lazy();

            Container.Bind<PlayerBoy>().FromInstance(playerBoy).AsSingle().Lazy();

            Container.Bind<InputListener>().FromInstance(inputListener).AsSingle();

            Container.Bind<AttackPerformer>().AsSingle().NonLazy();

            Container.Bind<EnemySwitcher>().AsSingle().NonLazy();

            Container.Bind<AEnemy>().To<EnemySkeleton>().FromInstance(enemySkeleton).AsSingle().Lazy();
            Container.Bind<AEnemy>().To<EnemyGoblin>().FromInstance(enemyGoblin).AsSingle().Lazy();
            Container.Bind<AEnemy>().To<EnemyMushroom>().FromInstance(enemyMushroom).AsSingle().Lazy();


            Container.Bind<IAttackStrategy>().To<UpToDownAttack>().WhenInjectedInto<AttackPerformer>();
            Container.Bind<IAttackStrategy>().To<DownToUpAttack>().WhenInjectedInto<AttackPerformer>();
            Container.Bind<IAttackStrategy>().To<NoScopeHardProAttack>().WhenInjectedInto<AttackPerformer>();
        }
    }
}