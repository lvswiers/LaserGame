﻿using UnityEngine;
using System.Collections;

namespace GameObjects {
    public class LaserSource: MonoBehaviour {

        public GameObject BulletPrefab;
        public float Speed;
        private GameObject Bullet;

        void Start() {
            instantiateBullet();
        }

        private Vector2 GetHorizontalPositionOfParent() {
            return transform.position; // Note there is an implicit conversion from Vector3 to Vector2 here
        }

        private void instantiateBullet() {
            Bullet = Instantiate(BulletPrefab);
            Bullet.GetComponent<Bullet>().startVelocity = new Vector3(-5f,0f,0f);
            Bullet.transform.position = GetHorizontalPositionOfParent();
        }

        public void StartMovingBullet() {
            Bullet bull = Bullet.GetComponent<Bullet>();
            Bullet.GetComponent<Bullet>().StartMoving();
        }

        public void ResetBullet() {
            if (Bullet != null) {
                Destroy(Bullet);
            }
            instantiateBullet();
        }
    }
}