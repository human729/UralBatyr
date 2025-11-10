using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, 9f, Player.transform.position.z - 6);
    }
}
