using UnityEngine;
using System.Collections;

public class LaserTarget : MonoBehaviour {

    private string tag = "Bullet";
    
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
        material.SetColor("_Color",new Color(0.2f, 0.5f, 0));
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision) {
        bool isDestroyed = destroyBullet(collision);

        if (isDestroyed){
            changeColour();
        }
    }
}
