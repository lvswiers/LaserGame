
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


        private void reflectOnSurface(Vector3 normal) {
            // Calculate the new velocity by using the normal vector of the surface and the original velocity, using projection/dot product
            // Example of a derivation: https://math.stackexchange.com/questions/13261/how-to-get-a-reflection-vector
            velocity = velocity - 2 * (Vector3.Dot(velocity, normal)* normal);
            
        }

        private void OnCollisionEnter(Collision collision) {
            Debug.Log("BOUNCe");
            // Todo: refactor game object inheritance to make sure we can assume that there is a normal again without using different types

            PlaceableMirror mirror = collision.gameObject.GetComponent<PlaceableMirror>();
            Obstruction obstruction = collision.gameObject.GetComponent<Obstruction>();

            if (mirror != null) {
                reflectOnSurface(mirror.Normal);
                Debug.Log("MIRROR");
            } else if(obstruction != null) {
                reflectOnSurface(obstruction.Normal);
            }
        }

        public void StartMoving() {
            velocity = startVelocity;
        }
    }
}
