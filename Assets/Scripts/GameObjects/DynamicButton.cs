using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Styling;

namespace GameObjects {
    public class DynamicButton : MonoBehaviour {

        private Color defaultColour = Colours.Yellow;
        private string defaultText = "Shoot!";
        private Color successColour = Colours.LightGreen;
        private Button button;

        private int attempts = 0;

        private void Start() {
            UpdateButton(defaultColour, defaultText);
            button = GetComponent<Button>();
        }

        public void Enable() {
            button.interactable = true;
        }

        public void Disable() {
            button.interactable = false;
        }

        void UpdateButton(Color colour, string text) {
            Button button = GetComponent<Button>();
            Text buttonText = GetComponent<Button>().GetComponentInChildren<Text>();
            buttonText.text = text;
            buttonText.color = colour;
        }

        public void OnSuccess(object sender, System.EventArgs e) {
            UpdateButton(successColour, $"Success after {attempts} attempt(s)!");
        }

        private string updateTextIfNotSucces(){
            if (attempts == 0) {
                return defaultText;
            } else {
                return $"{defaultText} {attempts} attempt(s) so far";
            }
        }

        public void UpdateNumberOfAttempts() {
            attempts += 1;
        }

        public void ResetButton() {
            UpdateButton(defaultColour, updateTextIfNotSucces());
        }
        
    }
}
