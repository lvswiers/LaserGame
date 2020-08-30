
using UnityEngine;
using System;
using Interfaces;

namespace GameObjects {
    public class Projectile : MonoBehaviour, IDestructable
    {
        [SerializeField]
        public Vector3 startVelocity;

        protected Vector3 velocity;

        // Update is called once per frame
        protected virtual void Update() {
            // Update position of Projectile using its velocity
            transform.position += velocity * Time.deltaTime;
        }

        public virtual void InitiateDestruction() {
            Destroy(this); // just a simple distruct
        }

        private void OnCollisionEnter(Collision collision) {
            
            Mirror mirror = collision.gameObject.GetComponent<Mirror>();
            if (mirror) {
                Vector3 normal = mirror.Normal;

            // Calculate the new velocity by using the normal vector of the mirror and the original velocity, using projection/dot product
            // Example of a derivation: https://math.stackexchange.com/questions/13261/how-to-get-a-reflection-vector
            velocity = velocity - 2 * (Vector3.Dot(velocity, normal)* normal);
            }  
        }

        public void StartMoving() {
            velocity = startVelocity;
        }
    }
}
