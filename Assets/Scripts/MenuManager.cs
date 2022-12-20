using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void switchScene(string sceneToChangeTo) {
        SceneManager.LoadScene(sceneToChangeTo);
    }

    public void exit() {
        Application.Quit();
    }
}
