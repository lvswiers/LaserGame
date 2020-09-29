using UnityEngine;

namespace GameObjects {
    public class InventoryItem : MonoBehaviour
    {
        public Material DefaultMaterial;
        public Material DisabledMaterial;

        public bool buildMode = true;

        private void UpdateColour() {
            Renderer renderer = GetComponent<Renderer>();
            if (!buildMode){
                renderer.material = DisabledMaterial;
            } else {
                renderer.material = DefaultMaterial;
            }
        }

        public void ToggleBuildMode() {
            buildMode = !buildMode;
            UpdateColour();
        }
    }
}