using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadButton : MonoBehaviour
{
    public void OnStartButtonClicked() {
        SceneManager.LoadScene("RootsFear");
    }

    public void OnMainMenuButtonClicked() {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnExitButtonCliked() {
        Application.Quit();
    }


}
