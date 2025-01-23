using System.Collections;
using UnityEngine;

namespace Projectiles
{
    public class Bullet : MonoBehaviour
    {
        public void Update()
        {
            transform.Translate(Vector2.right * (4 * Time.deltaTime));
        }

        private void OnEnable()
        {
            StartCoroutine(BulletLifeTime());
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private IEnumerator BulletLifeTime()
        {
            yield return new WaitForSeconds(1f);

            Destroy(gameObject);
        }
    }
}