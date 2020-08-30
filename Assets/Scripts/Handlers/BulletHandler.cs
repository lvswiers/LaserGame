using UnityEngine;
using GameObjects;
using System;

namespace Handlers {
    
    public class BulletHandler {

        private static bool destroyBullet(Collision collision, bool killFast = false) {
            GameObject collisionObject = collision.gameObject;

            try {
                Bullet bullet = collisionObject.GetComponent<Bullet>();
                if (killFast) {
                    bullet.Destroy();
                } else {
                    bullet.InitiateDestruction();
                }
                return true;
            } catch (Exception e) {
                return false;
            }
        }

        public static bool DestroyBullet(Collision collision) {
            return destroyBullet(collision);
        }

        public static bool DestroyBulletInstantly(Collision collision) {
            return destroyBullet(collision, true);
        }
    }
}