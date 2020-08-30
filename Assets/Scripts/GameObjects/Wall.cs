
using UnityEngine;
using Handlers;

namespace GameObjects {
    public class Wall : MonoBehaviour {

        void OnCollisionEnter(Collision collision) {
            bool isDestroyed = BulletHandler.DestroyBullet(collision);
        }
    }
}