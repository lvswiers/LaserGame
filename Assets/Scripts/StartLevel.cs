using UnityEngine;
using System.Collections;
using GameObjects;

public class StartLevel : MonoBehaviour {

    public Grid Grid;
    public float XRotation;
    public float YRotation;
    public float ZRotation;

    public PlaceableMirror[] mirrors;

    void Start() {
        Grid.gameObject.transform.Rotate(XRotation, YRotation, ZRotation);
    }

    public void ResetInventory() {
        foreach (var mirror in mirrors)
        {
            mirror.ResetPosition();
        }
    }

}
