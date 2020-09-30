using UnityEngine;

namespace GameObjects {
    public class Portal: Mirror {

        public GameObject PortalTwin;
        public Material PortalDisabledMaterial;
        public Material RegularMaterial;
        private bool teleported = false;
        private Vector3 offset;

        protected void Teleport(Projectile projectile) {
            offset = PortalTwin.transform.position - transform.position;
            float heightProjectile = projectile.GetPosition().z;
            Vector3 newPosition = projectile.transform.position + offset;
            newPosition.z = heightProjectile; // teleport horizontally
            projectile.UpdatePosition(newPosition);

            Portal portalTwinPortal = PortalTwin.GetComponentInChildren<Portal>();
            teleported = true;
            portalTwinPortal.SetTeleportedTrue();

            SetDisabledColour();
            portalTwinPortal.SetDisabledColour();
        }

        protected override void OnCollisionEnter(Collision collision) {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            if (projectile != null) {

                if (projectile != null) {
                    
                    if (teleported == false) { // to avoid incremental teleporting between the mirrors
                        base.OnCollisionEnter(collision);
                        Teleport(projectile);
                    } else {
                        // Now it acts as a regular mirror
                        base.OnCollisionEnter(collision);
                    }
                }
            }
        }

        public void SetDisabledColour() {
            GetComponent<Renderer>().material = PortalDisabledMaterial;
        }

        public void SetTeleportedTrue() {
            teleported = true;
        }

        public void ResetPortals() {
            teleported = false;
            GetComponent<Renderer>().material = RegularMaterial;
        }
    }
}