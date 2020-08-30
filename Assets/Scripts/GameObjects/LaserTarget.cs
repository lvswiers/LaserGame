using UnityEngine;
using System;
using Interfaces;
using Styling;
using Handlers;

namespace GameObjects {
    public class LaserTarget : MonoBehaviour, IEventGenerator {

        public event EventHandler Event;

        public void Start(){
            ResetTarget();
        }

        private void changeColour(Color colour) {
            var rend = GetComponent<Renderer>();
            Material material = rend.material;
            material.SetColor("_Color", colour);
        }

        private void raiseSuccess() {
            Event(this, EventArgs.Empty);
        }
    
        void OnCollisionEnter(Collision collision) {
            bool isDestroyed = BulletHandler.destroyBullet(collision);

            if (isDestroyed){
                changeColour(Colours.Green);
                raiseSuccess();
            }
        }

        public void ResetTarget() {
            changeColour(Colours.Red);
        }
    }
}
