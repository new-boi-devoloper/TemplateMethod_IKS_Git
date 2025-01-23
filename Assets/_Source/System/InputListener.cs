using Player;
using UnityEngine;

namespace System
{
    public class InputListener : MonoBehaviour
    {
        private AttackPerformer _attackPerformer;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                // _attackPerformer.PerformAttack();
                OnAttackCalled?.Invoke();
        }

        public event Action OnAttackCalled;
    }
}