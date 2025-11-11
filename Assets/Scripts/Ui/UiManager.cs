using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    private bool isPauseActive = false;
    private bool isSettingActive = false;
    [SerializeField] GameObject Setting;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPauseActive)
        {
            PauseMenu.SetActive(true);
            isPauseActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPauseActive)
        {
            PauseMenu.SetActive(false);
            isPauseActive = false;
        }
    }

    public void Continue()
    {
        PauseMenu.SetActive(false);
        isPauseActive = false;
    }

    public void OpenSettings()
    {
        isSettingActive = !isSettingActive;
        PauseMenu.SetActive(isSettingActive);
        Setting.SetActive(isSettingActive);
    }
}
