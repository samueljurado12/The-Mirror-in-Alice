using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static void LoadMainMenu() {
        SceneManager.LoadScene("01_MainMenu");
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void exit() {
        Debug.Log("Exit requested");
        Application.Quit();
    }

}
