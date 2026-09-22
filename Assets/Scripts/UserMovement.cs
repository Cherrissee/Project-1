using UnityEngine;

public class UserMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the user movement
    public float gravity = -9.81f; // Gravity value
    public Rigidbody rb;
    private float inputX;
    private float inputZ;
    private Vector2 input;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal"); // Get horizontal input (A/D or Left/Right arrow keys)
        input.y = Input.GetAxisRaw("Vertical"); // Get vertical input (W/S or Up/Down arrow keys)
        input.Normalize(); // Normalize the input vector to prevent faster diagonal movement

        Vector2 dir = new Vector2(input.x, input.y).normalized; // Normalize the input direction
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg; // Calculate the angle in degrees
        transform.rotation = Quaternion.Euler(0f, angle, 0f); // Rotate the user to face the movement direction


    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(input.x, gravity, input.y) * speed;
    }
}
