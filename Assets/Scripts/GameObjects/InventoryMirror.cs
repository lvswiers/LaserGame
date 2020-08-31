using UnityEngine;
using UnityEngine.EventSystems;
using Interfaces;
using Styling;

// Based on https://answers.unity.com/questions/12322/drag-gameobject-with-mouse.html
namespace GameObjects {
    public class InventoryMirror : Mirror
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