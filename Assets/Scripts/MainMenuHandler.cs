using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuHandler : MonoBehaviour
{

    public AudioMixer mainMixer;
    public TextMeshProUGUI soundText;
    private bool audioOn = true;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void SetVolume()
    {
        if(!audioOn)
        {
            mainMixer.SetFloat("Volume", 0f);
            soundText.text = "AUDIO: ON";
            audioOn=true;
        }
        else
        {
            mainMixer.SetFloat("Volume", -80f);
            soundText.text = "AUDIO: OFF";
            audioOn=false;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
