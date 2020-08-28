using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Styling;

namespace GameObjects {
    public class DynamicButton : MonoBehaviour {

        // todo: read up on serialisation of interfaces, so we can make it more generic here.
        // e.g. see https://answers.unity.com/questions/46210/how-to-expose-a-field-of-type-interface-in-the-ins.html
        // and https://answers.unity.com/questions/783456/solution-how-to-serialize-interfaces-generics-auto.html?_ga=2.121195080.1941949799.1591171570-2030961573.1591171570
        public LaserTarget EventGenerator;

        private Color defaultColour = Colours.Yellow;
        private string defaultText = "Shoot!";
        private Color successColour = Colours.LightGreen;

        private int attempts = 0;

        private void Start() {
            EventGenerator.Event += OnSuccess;
            UpdateButton(defaultColour, defaultText);
        }

        void UpdateButton(Color colour, string text, bool enable = true) {
            Button button = GetComponent<Button>();
            Text buttonText = GetComponent<Button>().GetComponentInChildren<Text>();
            buttonText.text = text;
            buttonText.color = colour;
            button.enabled = enable;
        }

        void OnSuccess(object sender, System.EventArgs e) {
            UpdateButton(successColour, $"Success after {attempts} attempt(s)!", false);
        }

        private string updateTextIfNotSucces(){
            if (attempts == 0) {
                return defaultText;
            } else {
                return $"{defaultText} {attempts} attempt(s) so far";
            }
        }

        public void NewAttempt() {
            attempts += 1;
        }

        public void ResetButton() {
            UpdateButton(defaultColour, updateTextIfNotSucces());
        }
        
    }
}
