using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject UpdatePanel;
    private void Start()
    {
        player = GameObject.Find("Player");
    }

    public void AddHealth()
    {
        player.GetComponent<PlayerBehaviour>().MaxHealth += 40;
        player.GetComponent<PlayerBehaviour>().Health = player.GetComponent<PlayerBehaviour>().MaxHealth;
    }

    public void AddSpeed()
    {
        player.GetComponent<MovementPlayer>().Speed += 0.2f;
    }

    public void LessArrowSpeed()
    {
        player.GetComponent<PlayerShoot>().ChargeTime -= 0.08f;
    }

   public void ClosePanel()
    {
        UpdatePanel.SetActive(false);
    }
}
