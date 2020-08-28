using UnityEngine;
using System.Collections;
using GameObjects;

public class StartLevel : MonoBehaviour {

    public PlaceableMirror[] mirrors;

    public void ResetInventory() {
        foreach (var mirror in mirrors)
        {
            mirror.ResetPosition();
        }
    }

}
