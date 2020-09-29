using UnityEngine;

namespace GameObjects{
    public class Mirror: MonoBehaviour {
        public Vector3 SpecialNormal;
        private bool useSpecialNormal = true;

        void Start() {
            if (SpecialNormal == new Vector3(0,0,0)) {
                useSpecialNormal = false;
            }
        }

        private void reflectOnSurface(Projectile collisionObject, Vector3 normal) {
            // Calculate the new velocity by using the normal vector of the surface and the original velocity, using projection/dot product
            // Example of a derivation: https://math.stackexchange.com/questions/13261/how-to-get-a-reflection-vector
            Vector3 velocity = collisionObject.Velocity;
            velocity = velocity - 2 * (Vector3.Dot(velocity, normal)* normal);
            collisionObject.UpdateVelocity(velocity);    
        }

        private bool nonMirrorPlane(Vector3 normal) {
            if (Vector3.Dot(normal, new Vector3(1,0,0)) == 0 || Vector3.Dot(normal, new Vector3(0,1,0)) == 0) {
                // We hit a vertical or horizontal plane, this is not the mirror side
                return true;
            } else {
                return false;
            }
        }

        protected void OnCollisionEnter(Collision collision) {

            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            
            Vector3 normal;
            if (projectile != null) {
                Vector3 collisionNormal = -1 * collision.contacts[0].normal; // multiply by minus 1 because the normals are inward 
                if (nonMirrorPlane(collisionNormal)) {
                    // we did not hit a mirror, use collision surface normally
                    normal = collisionNormal;
                }
                else {
                    // we hit the mirror side
                    if (useSpecialNormal) {
                        // we have a funky mirror with a special normal, use this one
                        normal = SpecialNormal;
                    } else {
                        normal = collisionNormal;
                    }
                }

                reflectOnSurface(projectile, normal);
            }
        }
    }
}