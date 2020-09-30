using UnityEngine;
using System.Collections;

namespace GameObjects {
    public class LaserSource: MonoBehaviour {

        public GameObject BulletPrefab;
        public Vector3 StartingVelocity = new Vector3(-5, 0, 0);
        private GameObject bulletContainer;
        private Bullet bullet;
        private Wall wall; 

        void Start() {
            wall = GetComponentInChildren<Wall>();
            instantiateBullet();
        }

        private void instantiateBullet() {
            bulletContainer = Instantiate(BulletPrefab);
            bulletContainer.transform.parent = this.transform;
            bullet = bulletContainer.GetComponentInChildren<Bullet>();
            bullet.startVelocity = StartingVelocity;

            // Set position of bullet to position of this object, but ignore the height of the object so the projectile follows the ground
            Vector3 startingPosition = transform.position;
            startingPosition.z = 0;
            bullet.UpdatePosition(startingPosition);

            // Temporarily turn off wall property
            wall.DeActivate();
        }

        public void StartMovingBullet() {
            bullet.StartMoving();
        }

        public void ResetBullet() {
            if (bulletContainer != null) {
                Destroy(bulletContainer);
            } 
            instantiateBullet();
        }

        void OnCollisionExit(Collision collision) {
            wall.Activate(); // activate wall property after the bullet has left
        }
    }
}