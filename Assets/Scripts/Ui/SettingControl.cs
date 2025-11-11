using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingControl : MonoBehaviour
{
    [SerializeField] Slider MasterVolume;
    [SerializeField] Slider MusicVolume;
    [SerializeField] Slider EffectVolume;
    [SerializeField] AudioMixer AudioMixer;

    public void OnMasterVolumeChanged()
    {
        AudioMixer.SetFloat("MasterVolume", MasterVolume.value);
    }

    public void OnMusicVolumeChanged()
    {
        AudioMixer.SetFloat("MusicVolume", MusicVolume.value);
    }

    public void OnEffectsVolumeChanged()
    {
        AudioMixer.SetFloat("EffectsVolume", EffectVolume.value);
    }
}
