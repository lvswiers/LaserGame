using UnityEngine;

namespace GameObjects{
    public class Mirror: MonoBehaviour {
        public Vector3 Normal; 

        private void reflectOnSurface(Projectile collisionObject) {
            // Calculate the new velocity by using the normal vector of the surface and the original velocity, using projection/dot product
            // Example of a derivation: https://math.stackexchange.com/questions/13261/how-to-get-a-reflection-vector
            Vector3 velocity = collisionObject.Velocity;
            velocity = velocity - 2 * (Vector3.Dot(velocity, Normal)* Normal);
            collisionObject.UpdateVelocity(velocity);    
        }

        // Have not been able to use MeshColliders with OnCollisionEnter yet, so using OnTriggerEnter instead
        protected void OnTriggerEnter(Collider collider) {
            Projectile projectile = collider.gameObject.GetComponent<Projectile>();

            if (projectile != null) {
                reflectOnSurface(projectile);
            }
        }
    }
}