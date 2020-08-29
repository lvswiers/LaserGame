using UnityEngine;
using UnityEngine.EventSystems;
using Interfaces;

// Based on https://answers.unity.com/questions/12322/drag-gameobject-with-mouse.html
namespace GameObjects {
    public class PlaceableMirror : Mirror
    {

        private Vector3 originalPosition;
        private Vector3 screenPoint;

        private bool floating = false;

        private GameManager gameManager;

        void Start(){
            originalPosition = transform.position;
            gameManager = FindObjectOfType<GameManager>();
        }

        void OnMouseDown()
        {
            if (gameManager.BuildMode){
                floating = true;
                screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            }
            
        }

        void OnMouseDrag()
        {
            if (gameManager.BuildMode){
            // Estimate screenpoint by using original z, correct for z later (camera angled)
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint);
            currentPosition.z = originalPosition.z; // correct position
            transform.position = currentPosition;
            }
        }

        private float getClosestGridPoint(float value){
           float newValue = Mathf.Round(value/0.5f)*0.5f;
           if (Mathf.Round(newValue) == newValue) {
               newValue += (newValue - value)/(newValue - value)*0.5f;
           }
           return newValue;

        }
        public void OnMouseUp() {
            if (gameManager.BuildMode){
                // snap object to grid
                float newx = getClosestGridPoint(transform.position.x);
                float newy = getClosestGridPoint(transform.position.y);
                transform.position = new Vector3 (newx, newy, transform.position.z);
                floating = false;
            }
        }

        public void ResetPosition() {
            transform.position = originalPosition;
        }

    }
}