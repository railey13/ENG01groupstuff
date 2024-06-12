using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    //audio
    [SerializeField] private AudioSource SelectSound;

    public void OnMainMenuClicked()
    {
        this.SelectSound.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void OnReplayClick()
    {
        this.SelectSound.Play();
        SceneManager.LoadScene("RootsFear");
    }
    public void OnExitClick()
    {
        this.SelectSound.Play();
        Application.Quit();
    }
    private void PlaySound()
    {
        this.SelectSound.Play();
    }
}
