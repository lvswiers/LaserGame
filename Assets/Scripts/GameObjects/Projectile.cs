
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

        // Update is called once per frame
        protected virtual void Update() {
            // Update position of Projectile using its velocity
            Container.transform.position += velocity * Time.deltaTime;
        }

        public virtual void InitiateDestruction() {
            Destroy(Container); // just a simple distruct
        }


        private void reflectOnSurface(Vector3 normal) {
            // Calculate the new velocity by using the normal vector of the surface and the original velocity, using projection/dot product
            // Example of a derivation: https://math.stackexchange.com/questions/13261/how-to-get-a-reflection-vector
            velocity = velocity - 2 * (Vector3.Dot(velocity, normal)* normal);
            
        }

        private void OnCollisionEnter(Collision collision) {
            Mirror mirror = collision.gameObject.GetComponent<Mirror>();
            Debug.Log(mirror);

            if (mirror != null) {
                reflectOnSurface(mirror.Normal);
            }
        }

        public void StartMoving() {
            velocity = startVelocity;
        }

        public void UpdatePosition(Vector3 newPosition) {
            Container.transform.position = newPosition;
        }
    }
}
