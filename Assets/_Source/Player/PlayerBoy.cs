using UnityEngine;

namespace Player
{
    public class PlayerBoy : MonoBehaviour
    {
        public Animator Animator { get; private set; }

        private void Start()
        {
            Animator = GetComponent<Animator>();
        }
    }
}