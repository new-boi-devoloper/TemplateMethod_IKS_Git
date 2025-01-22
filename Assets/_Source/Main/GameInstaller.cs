using System;
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

        public override void InstallBindings()
        {
            // Привязка интерфейса IClient к реализации ClientUI
            Container.Bind<ClientUI>().FromInstance(clientUI).AsSingle();

            // Привязка PlayerBoy
            Container.Bind<PlayerBoy>().FromInstance(playerBoy).AsSingle();

            // Привязка InputListener
            Container.Bind<InputListener>().FromInstance(inputListener).AsSingle();

            // Привязка AttackPerformer
            Container.Bind<AttackPerformer>().AsSingle();

            // Привязка стратегий атаки
            Container.Bind<IAttackStrategy>().To<UpToDownAttack>().WhenInjectedInto<AttackPerformer>();
            Container.Bind<IAttackStrategy>().To<DownToUpAttack>().WhenInjectedInto<AttackPerformer>();
            Container.Bind<IAttackStrategy>().To<NoScopeHardProAttack>().WhenInjectedInto<AttackPerformer>();
        }
    }
}