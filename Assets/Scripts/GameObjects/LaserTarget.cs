using UnityEngine;
using System.Collections;
using System;
using Interfaces;
using Styling;

public class LaserTarget : MonoBehaviour, EventGenerator {

    private string tag = "Bullet";
    public event EventHandler Event;
    
    private bool destroyBullet(Collision collision) {
        GameObject collisionObject = collision.gameObject;

        if (collisionObject.tag == tag) {
            Destroy(collisionObject);
            return true;
        } else {
            return false;
        }
    }

    private void changeColour() {
        var rend = GetComponent<Renderer>();
        Material material = rend.material;
        material.SetColor("_Color", Colours.Green);
    }

    private void raiseSuccess() {
        Event(this, EventArgs.Empty);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision) {
        bool isDestroyed = destroyBullet(collision);

        if (isDestroyed){
            changeColour();
            raiseSuccess();
        }
    }
}
