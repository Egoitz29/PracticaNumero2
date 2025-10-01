using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject settingsPanel;

    void Awake()
    {
        if (settingsPanel != null) settingsPanel.SetActive(false);
        // Aplica volumen guardado
        float vol = PlayerPrefs.GetFloat("master_volume", 1f);
        AudioListener.volume = vol;
        bool muted = PlayerPrefs.GetInt("master_muted", 0) == 1;
        if (muted) AudioListener.volume = 0f;
    }

    // BOTONES DE NAVEGACIÓN
    public void PlaySkyBubbles() => LoadScene("SkyBubbles");
    public void PlayGeoTreasure() => LoadScene("GeoTreasure");
    public void PlayARBlaster() => LoadScene("ARMarkerBlaster");
    public void OpenSocial() => LoadScene("SocialBridge");

    // AJUSTES
    public void OpenSettings() { if (settingsPanel) settingsPanel.SetActive(true); }
    public void CloseSettings() { if (settingsPanel) settingsPanel.SetActive(false); }

    // SALIR
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void LoadScene(string sceneName)
    {
        // Asegúrate de haber agregado las escenas al Build Settings
        SceneManager.LoadScene(sceneName);
    }
}

