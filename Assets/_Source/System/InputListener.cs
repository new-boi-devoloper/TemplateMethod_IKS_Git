using Player;
using UnityEngine;
using Zenject;

namespace System
{
    public class InputListener : MonoBehaviour
    {
        private AttackPerformer _attackPerformer;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("invoked");
                _attackPerformer.PerformAttack();
            }
        }

        [Inject]
        public void Construct(AttackPerformer attackPerformer)
        {
            _attackPerformer = attackPerformer;
        }
    }
}