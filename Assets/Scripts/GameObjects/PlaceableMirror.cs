using UnityEngine;
using UnityEngine.EventSystems;
using Interfaces;
using Styling;

// Based on https://answers.unity.com/questions/12322/drag-gameobject-with-mouse.html
namespace GameObjects {
    public class PlaceableMirror : PlaceableObject
    {
        public Vector3 Normal; 

        public Material DefaultMaterial;
        public Material DisabledMaterial;

        private void UpdateColour() {
            Renderer renderer = GetComponent<Renderer>();
            if (!buildMode){
                renderer.material = DisabledMaterial;
            } else {
                renderer.material = DefaultMaterial;
            }
        }

        public override void ToggleBuildMode() {
            buildMode = !buildMode;
            UpdateColour();
        }
    }
}