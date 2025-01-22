using System;
using UnityEngine;

namespace UI
{
    public enum AttackType
    {
        UpToDownAttackButton,
        DownToUpAttackButton,
        NoScopeHardProAttack
    }

    public class ClientUI : MonoBehaviour
    {
        public event Action<AttackType> OnAttackChanged;

        public void UpToDownAttackButton()
        {
            OnAttackChanged?.Invoke(AttackType.UpToDownAttackButton);
        }

        public void DownToUpAttackButton()
        {
            OnAttackChanged?.Invoke(AttackType.DownToUpAttackButton);
        }

        public void NoScopeHardProAttack()
        {
            OnAttackChanged?.Invoke(AttackType.NoScopeHardProAttack);
        }
    }
}