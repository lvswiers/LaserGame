using UnityEngine;

namespace GameObjects {
    public class Portal: Mirror {

        public GameObject PortalTwin;
        private Portal portalTwinPortal;
        public Material PortalDisabledMaterial;
        public Material RegularMaterial;
        private bool teleported = false;
        private Vector3 offset;
        private int bufferCycleCount;
        private bool buffering = false;
        private int numberOfBufferCycles = 3;

        void Start() {
            base.Start();
            portalTwinPortal = PortalTwin.GetComponentInChildren<Portal>();
        }

        protected void Teleport(Projectile projectile) {
            offset = PortalTwin.transform.position - transform.position;
            float heightProjectile = projectile.GetPosition().z;
            Vector3 newPosition = projectile.transform.position + offset;
            newPosition.z = heightProjectile; // teleport horizontally
            projectile.UpdatePosition(newPosition);

            // Turn on teleported state in both portals
            teleported = true;
            portalTwinPortal.SetTeleportedTrue();

            // Set material of both portals
            SetDisabledMaterial();
            portalTwinPortal.SetDisabledMaterial();

            // Turn on buffering on both portals
            StartBuffering();
            portalTwinPortal.StartBuffering();
        }

        void Update() {
            if (buffering) {
                bufferCycleCount += 1;
                if (bufferCycleCount > numberOfBufferCycles) {
                    buffering = false;
                }

            }
        }

        protected override void OnCollisionEnter(Collision collision) {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();

            if (projectile != null && buffering == false) {
                if (teleported == false) { // to avoid incremental teleporting between the mirrors
                    base.OnCollisionEnter(collision);
                    Teleport(projectile);
                } else {
                    // Now it acts as a regular mirror
                    base.OnCollisionEnter(collision);
                }
            }
      
        }

        public void StartBuffering() {
            buffering = true;
        }

        public void SetDisabledMaterial() {
            GetComponent<Renderer>().material = PortalDisabledMaterial;
        }

        public void SetTeleportedTrue() {
            teleported = true;
        }

        public void ResetPortals() {
            teleported = false;
            GetComponent<Renderer>().material = RegularMaterial;
            buffering = false;
            bufferCycleCount = 0;
        }
    }
}