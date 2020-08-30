using UnityEngine;
using GameObjects;
using System;

namespace Handlers {
    
    public class BulletHandler {

        public static bool destroyBullet(Collision collision) {
            GameObject collisionObject = collision.gameObject;

            try {
                Bullet bullet = collisionObject.GetComponent<Bullet>();
                bullet.InitiateDestruction();
                return true;
            } catch (Exception e) {
                Debug.LogWarning(e);
                return false;
            }
        }
    }
}