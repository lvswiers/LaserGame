using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Styling;

public class DynamicButton : MonoBehaviour {

    // todo: read up on serialisation of interfaces, so we can make it more generic here.
    // e.g. see https://answers.unity.com/questions/46210/how-to-expose-a-field-of-type-interface-in-the-ins.html
    // and https://answers.unity.com/questions/783456/solution-how-to-serialize-interfaces-generics-auto.html?_ga=2.121195080.1941949799.1591171570-2030961573.1591171570
    public LaserTarget EventGenerator;
    private string successText = "Success! ^^";

    private void Start() {
        EventGenerator.Event += UpdateText;
    }

    void UpdateText(object sender, System.EventArgs e) {
        Button button = GetComponent<Button>();
        Text buttonText = button.GetComponentInChildren<Text>();
        buttonText.text = successText;
        buttonText.color = Colours.LightGreen;
        button.GetComponent<Image>().color = Colours.DarkGrey; // why doesn't the disabled background colour work...
        button.enabled = false;

    }
    
}
