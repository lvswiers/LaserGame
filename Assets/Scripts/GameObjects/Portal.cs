using UnityEngine;

namespace GameObjects {
    public class Portal: Mirror {

        public GameObject PortalTwin;
        private bool teleported = false;
        private Vector3 offset;

        protected void Teleport(Projectile projectile) {
            offset = PortalTwin.transform.position - transform.position;
            float heightProjectile = projectile.GetPosition().z;
            Vector3 newPosition = projectile.transform.position + offset;
            newPosition.z = heightProjectile; // teleport horizontally
            projectile.UpdatePosition(newPosition);
            teleported = true;
            PortalTwin.GetComponentInChildren<Portal>().SetTeleportedTrue();
        }

        protected override void OnCollisionEnter(Collision collision) {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            if (projectile != null) {

                if (projectile != null) {
                    
                    if (teleported == false) { // to avoid incremental teleporting between the mirrors
                        base.OnCollisionEnter(collision);
                        Teleport(projectile);
                    }
                }
            }
        }

        public void SetTeleportedTrue() {
            teleported = true;
        }

        public void ResetTeleported() {
            teleported = false;
        }
    }
}