using UnityEngine;
using System.Collections;

public class StartLevel : MonoBehaviour {

    public Grid Grid;
    public float XRotation;
    public float YRotation;
    public float ZRotation;

    void Start() {
        Grid.gameObject.transform.Rotate(XRotation, YRotation, ZRotation);
    }
}
