using UnityEngine;

namespace GameObjects {
    public class Portal: Mirror {

        public GameObject PortalTwin;

        protected void Teleport(Projectile projectile) {
            Vector3 newPosition = PortalTwin.transform.position;
            newPosition.z = projectile.transform.position.z; // Only apply horizontal position of PortalTwin
            projectile.UpdatePosition(newPosition);
        }

        protected override void OnCollisionEnter(Collision collision) {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            if (projectile != null) {

                if (projectile != null) {
                    base.OnCollisionEnter(collision);
                    Teleport(projectile);
                }
            }
        }
    }
}