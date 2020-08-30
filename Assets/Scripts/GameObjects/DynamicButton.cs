using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Styling;

namespace GameObjects {
    public class DynamicButton : MonoBehaviour {

        private Color defaultColour = Colours.Yellow;
        private string defaultText = "Shoot!";
        private Color successColour = Colours.LightGreen;

        private int attempts = 0;

        private void Start() {
            UpdateButton(defaultColour, defaultText);
        }

        void UpdateButton(Color colour, string text, bool enable = true) {
            Button button = GetComponent<Button>();
            Text buttonText = GetComponent<Button>().GetComponentInChildren<Text>();
            buttonText.text = text;
            buttonText.color = colour;
            button.enabled = enable;
        }

        public void OnSuccess(object sender, System.EventArgs e) {
            UpdateButton(successColour, $"Success after {attempts} attempt(s)!", false);
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
