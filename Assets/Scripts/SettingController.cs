using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour

{
    [SerializeField] private Toggle muteToggle;
    [SerializeField] private Slider volumeSlider;

    void Start()
    {
        // Carga valores guardados
        bool muted = PlayerPrefs.GetInt("master_muted", 0) == 1;
        float vol = PlayerPrefs.GetFloat("master_volume", 1f);

        if (muteToggle) muteToggle.isOn = muted;
        if (volumeSlider) volumeSlider.value = vol;

        ApplyAudio(muted, vol);
        // Suscribir eventos
        if (muteToggle) muteToggle.onValueChanged.AddListener(OnMuteChanged);
        if (volumeSlider) volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    public void OnMuteChanged(bool isMuted)
    {
        PlayerPrefs.SetInt("master_muted", isMuted ? 1 : 0);
        ApplyAudio(isMuted, volumeSlider ? volumeSlider.value : 1f);
    }

    public void OnVolumeChanged(float vol)
    {
        PlayerPrefs.SetFloat("master_volume", vol);
        bool muted = PlayerPrefs.GetInt("master_muted", 0) == 1;
        ApplyAudio(muted, vol);
    }

    private void ApplyAudio(bool muted, float vol)
    {
        AudioListener.volume = muted ? 0f : Mathf.Clamp01(vol);
    }
}

