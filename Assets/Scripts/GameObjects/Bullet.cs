using UnityEngine;

namespace GameObjects {
    public class Bullet: Projectile {

        public GameObject BulletSphere;
        
        private int animationLengthUpdateCycles = 50;
        private bool isAnimating = false;
        private int currentNumberOfCycles = 0;

        private void applyAnimation(){
            BulletSphere.transform.localScale *= 1.01f; 
            velocity *= 0; // I would prefer a deceleration that is not instant, but this does not work well with low frame rates (todo?)
        }

        override protected void Update() {
            base.Update();
            if (isAnimating) {
                if (currentNumberOfCycles == animationLengthUpdateCycles) {
                    Destroy(Container);
                    isAnimating = false;
                } else{
                    applyAnimation();
                    currentNumberOfCycles += 1; 
                }
            } 
        }
        
        public override void InitiateDestruction() {
            isAnimating = true;
            currentNumberOfCycles = 0;
        }

        public void Destroy() {
            Destroy(Container);
        }

    }
}