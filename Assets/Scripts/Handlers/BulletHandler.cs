using UnityEngine;

namespace Handlers {
    
    public class BulletHandler {

        private static string tag = "Bullet";

        public static bool destroyBullet(Collision collision) {
            GameObject collisionObject = collision.gameObject;

            if (collisionObject.tag == tag) {
                Object.Destroy(collisionObject);
                return true;
            } else {
                return false;
            }
        }
    }
}