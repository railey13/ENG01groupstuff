using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadButton : MonoBehaviour
{
    public void OnStartButtonClicked() {
        SceneManager.LoadScene("Game");
    }

    public void OnMainMenuButtonClicked() {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnExitButtonCliked() {
        Application.Quit();
    }


}
