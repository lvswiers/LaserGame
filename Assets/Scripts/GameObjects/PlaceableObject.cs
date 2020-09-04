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

        protected virtual void Start() {
            originalPosition = transform.position;
        }

        void OnMouseDown() {
            if (buildMode){
                screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            }
            
        }

        void OnMouseDrag() {
            if (buildMode){
            // Estimate screenpoint by using original z, correct for z later (camera angled)
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint);
            currentPosition.z = originalPosition.z; // correct position
            transform.position = currentPosition;
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
                float newx = getClosestGridPoint(transform.position.x);
                float newy = getClosestGridPoint(transform.position.y);
                transform.position = new Vector3 (newx, newy, transform.position.z);
            }
        }

        public void ResetPosition() {
            transform.position = originalPosition;
        }

        public void ToggleBuildMode() {
            buildMode = !buildMode;
        }

    }
}