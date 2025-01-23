using System;
using Strategies;
using UI;
using Zenject;

namespace Player
{
    public class AttackPerformer
    {
        private readonly ClientUI _clientUI;
        private readonly PlayerBoy _playerBoy;
        private IAttackStrategy _currentAttack;
        private readonly InputListener _inputListener;

        [Inject]
        public AttackPerformer(PlayerBoy playerBoy, ClientUI clientUI, InputListener inputListener)
        {
            _playerBoy = playerBoy;
            _clientUI = clientUI;
            _inputListener = inputListener;

            _clientUI.OnAttackChanged += HandleAttackChanged;
            _inputListener.OnAttackCalled += PerformAttack;
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

        private void PerformAttack()
        {
            OnAttackPerformed?.Invoke();
            _currentAttack.PlayAnim(_playerBoy.Animator);
        }

        public event Action OnAttackPerformed;
    }
}