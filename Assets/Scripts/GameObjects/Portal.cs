using UnityEngine;

namespace GameObjects {
    public class Portal: Mirror {

        public GameObject PortalTwin;

        private bool postTeleport = false; // bool to prevent from infinite teleporting

        protected void Teleport(Projectile projectile) {
            Debug.Log("pororr");
            Vector3 newPosition = PortalTwin.transform.position;
            newPosition.z = projectile.transform.position.z; // Only apply horizontal position of PortalTwin
            projectile.UpdateVelocity(newPosition);
        }

        protected override void OnCollisionEnter(Collision collision) {
            Debug.Log(postTeleport);
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            if (postTeleport == false && projectile != null) {
                Debug.Log("tellele");
                

                if (projectile != null) {
                    base.OnCollisionEnter(collision);
                    Teleport(projectile);
                }

                SetPostTeleport();
                PortalTwin.GetComponentInChildren<Portal>().SetPostTeleport();
            }
        }

        public void SetPostTeleport() {
            postTeleport = true;
        }

        public void ResetTeleportState() {
            postTeleport = false;
        }
    }
}