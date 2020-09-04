using UnityEngine;
using System.Collections;

namespace GameObjects {
    public class LaserSource: MonoBehaviour {

        public GameObject BulletPrefab;
        public float Speed;
        private GameObject BulletContainer;
        private Bullet Bullet;

        void Start() {
            instantiateBullet();
        }

        private void instantiateBullet() {
            BulletContainer = Instantiate(BulletPrefab);
            BulletContainer.transform.parent = this.transform;
            Bullet = BulletContainer.GetComponentInChildren<Bullet>();
            Bullet.startVelocity = new Vector3(-1f,0f,0f) * Speed;

            // Set position of bullet to position of this object, but ignore the height of the object so the projectile follows the ground
            Vector3 startingPosition = transform.position;
            startingPosition.z = 0;
            Bullet.UpdatePosition(startingPosition);
        }

        public void StartMovingBullet() {
            Bullet.StartMoving();
        }

        public void ResetBullet() {
            if (BulletContainer != null) {
                Destroy(BulletContainer);
            } 
            instantiateBullet();
        }
    }
}