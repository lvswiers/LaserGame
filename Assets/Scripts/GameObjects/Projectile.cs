
using UnityEngine;
using Domain;
using System;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public Vector3 startVelocity;
    public Direction direction;

    private Vector3 velocity;

    // Update is called once per frame
    void Update() {
        transform.position += velocity * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision) {
        
            GameObject obj = collision.gameObject;
            Mirror mirror = collision.gameObject.GetComponent<Mirror>();
            Vector3 normal = mirror.Normal;
            velocity = velocity - 2 * (Vector3.Dot(velocity, normal)* normal);
        
    }

    public void StartMoving() {
        velocity = startVelocity;
    }

}
