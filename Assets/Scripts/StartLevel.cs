using UnityEngine;
using System.Collections;

public class StartLevel : MonoBehaviour {

    public Grid Grid;
    public float xRotation;
    public float yRotation;
    public float zRotation;

    void Start() {
        Grid.gameObject.transform.Rotate(xRotation, yRotation, zRotation);
    }
}
