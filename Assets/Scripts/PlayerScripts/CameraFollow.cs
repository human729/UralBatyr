using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    public float MouseSensitivity;
    public float MaxXOffset = 10f;
    public float MaxZOffset = 10f;
    public float MoveSpeed = 5f;
    public float EdgeThresholdX = 50f;
    public float EdgeThresholdY = 50f;

    private Vector3 targetOffset;
    private Vector3 currentOffset;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        HandleEdgeMovement();
        currentOffset = Vector3.Lerp(currentOffset, targetOffset, 10f * Time.deltaTime);
        transform.position = new Vector3(Player.transform.position.x + currentOffset.x, 12f, Player.transform.position.z - 6 + currentOffset.z);
    }

    void HandleEdgeMovement()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector3 moveDirection = Vector3.zero;

        if (mousePos.x <= EdgeThresholdX)
        {
            moveDirection.x = -1f; 
        }
        else if (mousePos.x >= Screen.width - EdgeThresholdX)
        {
            moveDirection.x = 1f; 
        }

        if (mousePos.y <= EdgeThresholdY)
        {
            moveDirection.z = -1f; 
        }
        else if (mousePos.y >= Screen.height - EdgeThresholdY)
        {
            moveDirection.z = 1f; 
        }

 
        if (moveDirection != Vector3.zero)
        {
            targetOffset += moveDirection * MoveSpeed * Time.deltaTime;
        }
        else
        {
            targetOffset = Vector3.Lerp(targetOffset, Vector3.zero, MoveSpeed * Time.deltaTime);
        }

        targetOffset.x = Mathf.Clamp(targetOffset.x, -MaxXOffset, MaxXOffset);
        targetOffset.z = Mathf.Clamp(targetOffset.z, -MaxZOffset, MaxZOffset);
    }

}
