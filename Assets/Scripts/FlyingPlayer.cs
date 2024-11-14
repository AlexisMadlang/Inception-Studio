using UnityEngine;

public class FlyingPlayer : MonoBehaviour
{
    public float speed = 10f; // Speed for movement
    public float upDownSpeed = 5f; // Speed for moving up and down
    public float lookSpeed = 2f; // Mouse look sensitivity

    private Rigidbody rb;
    private Camera playerCamera;

    void Start()
    {
        // Get the Rigidbody and Camera components
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main;

        // Disable gravity
        rb.useGravity = false;

        // Lock the cursor to the center of the screen (useful for first-person view)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Mouse look (rotate the player)
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        // Rotate the player horizontally (around Y-axis)
        transform.Rotate(0, mouseX, 0);

        // Rotate the camera vertically (around X-axis, clamping to avoid flipping)
        playerCamera.transform.Rotate(-mouseY, 0, 0);
        float xRotation = playerCamera.transform.rotation.eulerAngles.x;
        if (xRotation > 180f) xRotation -= 360f; // Clamp the angle between -180 and 180
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.transform.rotation = Quaternion.Euler(xRotation, playerCamera.transform.rotation.eulerAngles.y, 0);

        // Movement input
        float moveForwardBack = 0f;
        float moveLeftRight = 0f;
        float moveUpDown = 0f;

        // Moving forward and backward with Arrow Up/Down
        if (Input.GetKey(KeyCode.UpArrow)) // Move forward
        {
            moveForwardBack = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow)) // Move backward
        {
            moveForwardBack = -1f;
        }

        // Moving left and right with Arrow Left/Right
        if (Input.GetKey(KeyCode.LeftArrow)) // Move left
        {
            moveLeftRight = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow)) // Move right
        {
            moveLeftRight = 1f;
        }

        // Moving up and down with W/S
        if (Input.GetKey(KeyCode.W)) // Move up
        {
            moveUpDown = 1f;
        }
        else if (Input.GetKey(KeyCode.S)) // Move down
        {
            moveUpDown = -1f;
        }

        // Get the movement direction based on the camera's forward and right vectors
        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;
        forward.y = 0f; // Ignore the up/down component of the camera's forward direction
        right.y = 0f; // Ignore the up/down component of the camera's right direction

        forward.Normalize();
        right.Normalize();

        // Calculate movement direction based on the player's input
        Vector3 move = forward * moveForwardBack + right * moveLeftRight + transform.up * moveUpDown;

        // Apply movement to the Rigidbody
        rb.velocity = new Vector3(move.x, move.y, move.z) * speed * Time.deltaTime; // Apply movement speed
    }
}
