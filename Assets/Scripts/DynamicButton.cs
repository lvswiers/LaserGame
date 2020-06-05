using UnityEngine;
using System.Collections;

public class DynamicButton : MonoBehaviour {

    // todo: read up on serialisation of interfaces, so we can make it more generic here.
    // e.g. see https://answers.unity.com/questions/46210/how-to-expose-a-field-of-type-interface-in-the-ins.html
    // and https://answers.unity.com/questions/783456/solution-how-to-serialize-interfaces-generics-auto.html?_ga=2.121195080.1941949799.1591171570-2030961573.1591171570
    public LaserTarget EventGenerator; 

    private void Start() {
        EventGenerator.Event += UpdateText;
    }

    void UpdateText(object sender, System.EventArgs e) {
        print("SUCCES");
    }
    
}
