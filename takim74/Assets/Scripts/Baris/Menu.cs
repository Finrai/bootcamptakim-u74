using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public GameObject[] game;
    //Çözünürlük ve ekran büyütüp küçültme
    public Toggle fullscreenTog, vsyncTog;
    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResolution;
    public TMP_Text resolutionLabel;


    public AudioMixer audioMixer;
    public AudioMixer _audioMixer;

    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }
        bool foundRes = false;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width ==  resolutions[i].horizontal && Screen.height == resolutions[i].verical)
            {
                foundRes = true;
                selectedResolution = i;
                UpdateResLabel();
            }
        }
        if (!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.verical = Screen.height;
            resolutions.Add(newRes);
            selectedResolution = resolutions.Count - 1;
            UpdateResLabel();
        }
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //yükleme
    public void aboutButton()
    {
        game[2].SetActive(true);
        game[0].SetActive(false);
    }


    

    //ayarlar
    public void Settings()
    {
        game[1].SetActive(true);
        game[0].SetActive(false);
    }
    //çýkýþ
    public void Quit()
    {
        Application.Quit();
    }
    //geri
    public void back()
    {
        game[2].SetActive(false);
        game[1].SetActive(false);
        game[0].SetActive(true);
    }


    //Grafik
    public void low()
    {
        QualitySettings.SetQualityLevel(0);
    }

    public void medium()
    {
        QualitySettings.SetQualityLevel(1);
    }

    public void high()
    {
        QualitySettings.SetQualityLevel(2);
    }


    //Çözünürlük ve ekran büyütüp küçültme
    public void ResLeft()
    {
        selectedResolution--;
        if (selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdateResLabel();
    }
    public void ResRight()
    {
        selectedResolution++;
        if (selectedResolution > resolutions.Count - 1)
        {
            selectedResolution = resolutions.Count - 1;
        }
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].verical.ToString();
    }


    public void ApplyGraphics()
    {
        Screen.fullScreen = fullscreenTog.isOn;

        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].verical, fullscreenTog.isOn);
    }


    //Audio
    public void SetVolue(float volue)
    {
        Debug.Log(volue);
        audioMixer.SetFloat("volume", volue);
    }
    public void Setmusic(float music)
    {
        Debug.Log(music);
        _audioMixer.SetFloat("music", music);
    }
}
[System.Serializable]
public class ResItem
{
    public int horizontal, verical;
}
