using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UniStorm;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    int currentQualityIndex;
    
    [SerializeField]
    private TMP_Dropdown qualityDropdown;

    [SerializeField]
    private Slider masterVolumeSlider;

    [SerializeField]
    private Slider musicVolumeSlider;

    public AudioMixer audioMixer;

    void Awake()
    {
        
    }

    void Start()
    {
        currentQualityIndex = PlayerPrefs.GetInt("_qualityIndex", 3);
        qualityDropdown.value = currentQualityIndex;
        QualitySettings.SetQualityLevel(currentQualityIndex);

        masterVolumeSlider.value = PlayerPrefs.GetFloat("_masterVolume", 1f);

        musicVolumeSlider.value = PlayerPrefs.GetFloat("_musicVolume", 1f);
    }

    void Update()
    {
        UniStorm.UniStormManager.Instance.SetMusicVolume(PlayerPrefs.GetFloat("_musicVolume", 1f));
        SetMasterVolume(PlayerPrefs.GetFloat("_masterVolume", 1f));
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

        PlayerPrefs.SetInt("_qualityIndex", qualityIndex);
    }

    public void SetMasterVolume (float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log(volume) * 20);
        if (volume <= 0)
        {
            volume = 0.001f;
        }
        else if (volume > 1)
        {
            volume = 1;
        }
        audioMixer.SetFloat("MasterVolume", Mathf.Log(volume) * 20);
        PlayerPrefs.SetFloat("_masterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        if (UniStormSystem.Instance.UniStormInitialized)
        {
            UniStorm.UniStormManager.Instance.SetMusicVolume(volume);
        }
        PlayerPrefs.SetFloat("_musicVolume", volume);
    }

    public void DeleteSaveData()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
