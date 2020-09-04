using UnityEngine;
using UnityEngine.EventSystems;
using Interfaces;
using Styling;

// Based on https://answers.unity.com/questions/12322/drag-gameobject-with-mouse.html
namespace GameObjects {
    public class PlaceableObject: MonoBehaviour
    {
        private Vector3 originalPosition;
        private Vector3 screenPoint;
        protected bool buildMode = true;

        private GameObject Container; // represents container and locatable gameobject

        protected virtual void Start() {
            // Assume script is linked to child with collision properties
            Container = transform.parent.gameObject;
            originalPosition = Container.transform.position;
        }

        void OnMouseDown() {
            if (buildMode){
                screenPoint = Camera.main.WorldToScreenPoint(Container.transform.position);
            }
        }

        void OnMouseDrag() {
            if (buildMode){
            // Estimate screenpoint by using original z, correct for z later (camera angled)
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint);
            currentPosition.z = originalPosition.z; // correct position
            Container.transform.position = currentPosition;
            }
        }

        private float getClosestGridPoint(float value) {
           float newValue = Mathf.Round(value/0.5f)*0.5f;
           if (Mathf.Round(newValue) == newValue) {
               newValue += (newValue - value)/(newValue - value)*0.5f;
           }
           return newValue;

        }
        public void OnMouseUp() {
            if (buildMode){
                // snap object to grid
                float newx = getClosestGridPoint(Container.transform.position.x);
                float newy = getClosestGridPoint(Container.transform.position.y);
                Container.transform.position = new Vector3 (newx, newy, Container.transform.position.z);
            }
        }

        public void ResetPosition() {
            Container.transform.position = originalPosition;
        }

        public void ToggleBuildMode() {
            buildMode = !buildMode;
        }

    }
}