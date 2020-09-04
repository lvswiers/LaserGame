
using UnityEngine;
using Handlers;

namespace GameObjects {
    public class Wall : MonoBehaviour {

        public bool isActive = true;

        void OnCollisionEnter(Collision collision) {
            if (isActive) {
                bool isDestroyed = BulletHandler.DestroyBullet(collision);
            }
        }

        public void Activate() {
            isActive = true;
        }

        public void DeActivate() {
            isActive = false;
        }
    }
}