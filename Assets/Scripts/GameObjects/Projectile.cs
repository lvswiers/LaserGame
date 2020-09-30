
using UnityEngine;
using System;
using Interfaces;

namespace GameObjects {
    public class Projectile : MonoBehaviour, IDestructable
    {
        [SerializeField]
        public Vector3 startVelocity;

        protected Vector3 velocity;

        public GameObject Container; // Represents container and locator of projectile

        public Vector3 Velocity {
            get { return velocity; }
        }

        // Update is called once per frame
        protected virtual void Update() {
            // Update position of Projectile using its velocity
            Container.transform.position += velocity * Time.deltaTime;
        }

        public virtual void InitiateDestruction() {
            Destroy(Container); // just a simple distruct
        }

        public void StartMoving() {
            velocity = startVelocity;
        }

        public void UpdatePosition(Vector3 newPosition) {
            Container.transform.position = newPosition;
        }

        public void UpdateVelocity(Vector3 newVelocity) {
            velocity = newVelocity;
        }

        public Vector3 GetPosition() {
            return Container.transform.position;
        }
    }
}
