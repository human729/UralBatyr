using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public PlayerBehaviour player;

    private void Start()
    {
        if (player != null)
        {
            //slider.maxValue = player.MaxHealth;
            slider.value = player.Health;
        }
    }

    void Update()
    {
        if (player != null)
        {
            slider.value = player.Health;
        }
    }
}