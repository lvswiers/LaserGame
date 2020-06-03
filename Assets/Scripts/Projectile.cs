
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public float speed;
    private float actualSpeed;

    private void Start() {
        actualSpeed = speed;
    }

    // Update is called once per frame
    void Update ()
    {
        transform.position += transform.right * Time.deltaTime * actualSpeed;
    }

    private void OnCollisionEnter(Collision collision) {
        actualSpeed = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        actualSpeed = 0;
    }

    private void OnCollisionExit(Collision collision) {
        actualSpeed = 0;
    }

}
