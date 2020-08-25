
using UnityEngine;
using Domain;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public Direction direction;

    private float actualSpeed = 0;
    private Direction currentDirection;

    // Update is called once per frame
    void Update() {
        switch (currentDirection) {
            case Direction.RIGHT:
                transform.position += transform.right * Time.deltaTime * actualSpeed;
                break;
            case Direction.LEFT:
                transform.position += transform.right * Time.deltaTime * -1 * actualSpeed;
                break;
            case Direction.UP:
                transform.position += transform.up * Time.deltaTime * actualSpeed;
                break;
            case Direction.DOWN:
                transform.position += transform.up * Time.deltaTime * -1 * actualSpeed;
                break;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        Transform tf = collision.gameObject.transform;
        float zAngle = tf.rotation.z;
        bool isPositive = zAngle > 0; // assume angles can only be +-45deg

        switch ((isPositive, currentDirection)) { // todo: there is probably a more elegant solution for this
            case var c when c == (true, Direction.LEFT):
                currentDirection = Direction.DOWN;
                break;
            case var c when c == (true, Direction.RIGHT):
                currentDirection = Direction.UP;
                break;
            case var c when c == (true, Direction.UP):
                currentDirection = Direction.RIGHT;
                break;
            case var c when c == (true, Direction.DOWN):
                currentDirection = Direction.LEFT;
                break;
            case var c when c == (false, Direction.LEFT):
                currentDirection = Direction.UP;
                break;
            case var c when c == (false, Direction.RIGHT):
                currentDirection = Direction.DOWN;
                break;
            case var c when c == (false, Direction.UP):
                currentDirection = Direction.LEFT;
                break;
            case var c when c == (false, Direction.DOWN):
                currentDirection = Direction.RIGHT;
                break;
        }
    }

    public void StartMoving() {
        actualSpeed = speed; // todo: check if positive or enforce
    }

}
