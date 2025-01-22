using System;
using Strategies;
using UI;
using UnityEngine;
using Zenject;

namespace Player
{
    public class AttackPerformer
    {
        private readonly ClientUI _clientUI;
        private readonly PlayerBoy _playerBoy;
        private IAttackStrategy _currentAttack;
        private InputListener _inputListener;

        [Inject]
        public AttackPerformer(PlayerBoy playerBoy, ClientUI clientUI)
        {
            Debug.Log("AttackPerformer made");
            _playerBoy = playerBoy;
            _clientUI = clientUI;

            _clientUI.OnAttackChanged += HandleAttackChanged;
            Debug.Log("started to listen");
        }


        private void HandleAttackChanged(AttackType attackType)
        {
            switch (attackType)
            {
                case AttackType.UpToDownAttackButton:
                    _currentAttack = new UpToDownAttack();
                    break;
                case AttackType.DownToUpAttackButton:
                    _currentAttack = new DownToUpAttack();
                    break;
                case AttackType.NoScopeHardProAttack:
                    _currentAttack = new NoScopeHardProAttack();
                    break;
            }

            PerformAttack();
        }

        public void PerformAttack()
        {
            OnAttackPerformed?.Invoke();
            _currentAttack.PlayAnim(_playerBoy.Animator);
        }

        public event Action OnAttackPerformed;
    }
}