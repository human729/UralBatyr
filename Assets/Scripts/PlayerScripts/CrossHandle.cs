using UnityEngine;
using UnityEngine.UI;

public class CrossHandle : MonoBehaviour
{
    public Transform playerTransform; // Assign your player's transform in the Inspector
    public Camera playerCamera; // Assign your main player camera
    public float crosshairDistance = 5f; // Distance of the crosshair from the player

    private Plane groundPlane;

    void Start()
    {
        // Define the ground plane at the player's Y position
        groundPlane = new Plane(Vector3.up, playerTransform.position);
    }

    void Update()
    {
        Ray camRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        float rayLength;

        if (groundPlane.Raycast(camRay, out rayLength))
        {
            Vector3 pointToLook = camRay.GetPoint(rayLength);

            // Calculate the direction from the player to the point on the ground plane
            Vector3 direction = pointToLook - playerTransform.position;
            direction.y = 0; // Ensure rotation is only on the horizontal plane

            if (direction != Vector3.zero)
            {
                // Rotate the crosshair to face the mouse position
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = targetRotation;

                // Position the crosshair at a fixed distance in front of the player
                transform.position = playerTransform.position + direction.normalized * crosshairDistance;
            }
        }
    }
}
