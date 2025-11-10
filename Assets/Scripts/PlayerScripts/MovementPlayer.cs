using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float Speed = 0f;

    private CharacterController characterController;
    float horizontal;
    float vertical;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(horizontal, 0, vertical) * Speed * Time.deltaTime;
        characterController.Move(moveVector);
    }
}
