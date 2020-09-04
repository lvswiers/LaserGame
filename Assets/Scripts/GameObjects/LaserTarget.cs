using UnityEngine;
using System;
using Interfaces;
using Styling;
using Handlers;

namespace GameObjects {
    public class LaserTarget : MonoBehaviour, IEventGenerator {

        public event EventHandler Event;
        public Material DefaultMaterial;
        public Material SuccessMaterial;

        public void Start(){
            ResetTarget();
        }

        private void changeMaterial(Material material) {
            GetComponent<Renderer>().material = material;
        }

        private void raiseSuccess() {
            Event(this, EventArgs.Empty);
        }
    
        void OnCollisionEnter(Collision collision) {
            bool isDestroyed = BulletHandler.DestroyBulletInstantly(collision);

            if (isDestroyed){
                changeMaterial(SuccessMaterial);
                raiseSuccess();
            }
        }

        public void ResetTarget() {
            changeMaterial(DefaultMaterial);
        }
    }
}
