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

        private GameObject container; // represents container and locatable gameobject
        private Vector3 offsetContainerAndThisObject;

        protected virtual void Start() {
            // Assume script is linked to child with collision properties
            container = transform.parent.gameObject;
            offsetContainerAndThisObject = container.transform.position - transform.position;
            originalPosition = container.transform.position;
        }

        void OnMouseDown() {
            if (buildMode){
                screenPoint = Camera.main.WorldToScreenPoint(container.transform.position);
            }
        }

        void OnMouseDrag() {
            if (buildMode){
            // Estimate screenpoint by using original z, correct for z later (camera angled)
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint);
            currentPosition += offsetContainerAndThisObject; // correct offset between parent and this object;
            currentPosition.z = originalPosition.z; // correct height;
            container.transform.position = currentPosition;
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
                float newx = getClosestGridPoint(container.transform.position.x);
                float newy = getClosestGridPoint(container.transform.position.y);
                container.transform.position = new Vector3 (newx, newy, container.transform.position.z);
            }
        }

        public void ResetPosition() {
            container.transform.position = originalPosition;
        }

        public void ToggleBuildMode() {
            buildMode = !buildMode;
        }

    }
}