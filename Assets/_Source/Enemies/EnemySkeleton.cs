using UnityEngine;

namespace Enemies
{
    public class EnemySkeleton : AEnemy
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private float attackInterval = 2f;

        private float _attackTimer;

        protected override void Start()
        {
            base.Start();
            Debug.Log("skeleton started");

            _attackTimer = attackInterval;
        }

        private void Update()
        {
            Debug.Log("shooting");
            if (gameObject.activeInHierarchy)
            {
                _attackTimer -= Time.deltaTime;

                if (_attackTimer <= 0)
                {
                    Attack();
                    _attackTimer = attackInterval;
                }
            }
        }

        public override void Attack()
        {
            if (gameObject != null)
            {
                Animator.SetTrigger(EnemyAnims.Attack);
                Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
            }
            else
            {
                Debug.Log("save");
            }
        }

        public override void Stop()
        {
            StopAllCoroutines();
            Animator.SetFloat(EnemyAnims.Speed, 0f);
        }
    }
}