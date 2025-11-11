using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Settings;
    public void ToggleSettings()
    {
        if (Settings.activeInHierarchy)
        {
            Settings.SetActive(false);
        } else
        {
            Settings.SetActive(true);
        }
    }
}
