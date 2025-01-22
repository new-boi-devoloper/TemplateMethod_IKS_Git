using System.Collections;
using UnityEngine;

namespace Enemies
{
    public class EnemySkeleton : AEnemy
    {
        public GameObject projectilePrefab;
        public Transform shootPoint;

        private void Start()
        {
            StartCoroutine(SpamAttack());
        }

        private IEnumerator SpamAttack()
        {
            while (true)
            {
                Attack();
                yield return new WaitForSeconds(1f); // Adjust delay as needed
            }
        }

        public override void Attack()
        {
            animator.SetTrigger(EnemyAnims.Attack);
            Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        }

        public override void Stop()
        {
            StopAllCoroutines();
            animator.SetTrigger(EnemyAnims.Idle);
        }
    }
}