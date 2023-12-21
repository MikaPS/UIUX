using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 2f;
    public float moveSpeed = 5f;
    public float maxCameraDistance = 10f;
    public float minCameraDistance = 2f;

    private float rotationX = 0f;

    void Update()
    {
        // Handle mouse input for camera rotation
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Clamp vertical rotation to avoid flipping the camera
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Rotate the player and camera based on mouse input
        player.Rotate(Vector3.up * inputX);
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // Calculate the desired camera position with the offset
        Vector3 desiredCameraPos = player.position - transform.forward * maxCameraDistance;

        // Limit the camera distance to a minimum value
        float distance = Mathf.Clamp(Vector3.Distance(player.position, transform.position), minCameraDistance, maxCameraDistance);

        // Set the camera position
        transform.position = player.position - transform.forward * distance;

        // Handle player movement in the direction the camera is facing
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        moveDirection = player.TransformDirection(moveDirection);

        // Move the player based on input
        player.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
