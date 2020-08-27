using UnityEngine;
using UnityEngine.EventSystems;
using Interfaces;

// Based on https://answers.unity.com/questions/12322/drag-gameobject-with-mouse.html
namespace GameObjects {
    public class PlaceableMirror : Mirror
    {
        private Vector3 screenPoint;
        private Vector3 offset;

        private Vector3 originalPosition;

        private bool floating = false;

        void Start(){
            originalPosition = transform.position;
        }

        void OnMouseDown()
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            floating = true;
        }
        
        void OnMouseDrag()
        {
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
            transform.position = currentPosition;
        }

        private float getClosestGridPoint(float value){
           float newValue = Mathf.Round(value/0.5f)*0.5f;
           if (Mathf.Round(newValue) == newValue) {
               newValue += (newValue - value)/(newValue - value)*0.5f;
           }
           return newValue;

        }
        public void OnMouseUp() {
            // snap object to grid
            float newx = getClosestGridPoint(transform.position.x);
            float newy = getClosestGridPoint(transform.position.y);
            transform.position = new Vector3 (newx, newy, transform.position.z);
            floating = false;
        }

        public void ResetPosition() {
            transform.position = originalPosition;
        }

    }
}