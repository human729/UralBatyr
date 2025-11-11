using UnityEngine;

public class UpgradeItem : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject UpdatePanel;
    private void Start()
    {
        player = GameObject.Find("Player");
    }

    public void AddHealth()
    {
        player.GetComponent<PlayerBehaviour>().Health += 40;
    }

    public void AddSpeed()
    {
        player.GetComponent<MovementPlayer>().Speed += 0.2f;
    }

    public void LessArrowSpeed()
    {
        player.GetComponent<PlayerShoot>().ChargeTime -= 0.08f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !UpdatePanel.activeSelf)
        {
            UpdatePanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            UpdatePanel.SetActive(false);
        }
    }
}
