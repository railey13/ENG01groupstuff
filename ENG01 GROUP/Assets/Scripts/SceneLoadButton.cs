using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadButton : MonoBehaviour
{
    //audio
    [SerializeField] private AudioSource SelectSound;

    public void OnStartButtonClicked() {
        this.SelectSound.Play();
        SceneManager.LoadScene("RootsFear");
    }

    public void OnMainMenuButtonClicked() {
        this.SelectSound.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void OnExitButtonCliked()
    {
        this.SelectSound.Play();
        Application.Quit();
    }

    private void PlaySound()
    {
        this.SelectSound.Play();
    }
}
