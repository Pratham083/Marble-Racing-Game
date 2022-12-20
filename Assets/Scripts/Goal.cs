using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject endScreenUI;
    public TMPro.TextMeshProUGUI finishTime;
    public GameObject timer;
    public static bool finishedGame;

    void Start() {
        finishedGame = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        MarbleController component = other.gameObject.GetComponent<MarbleController>();
        if (component != null)
        {
            timer.SetActive(false);
            finishedGame = true;
            TimerController.instance.EndTimer();
            float time = TimerController.instance.getTime();
            // show end screen
            endScreenUI.SetActive(true);
            //slow mo
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            // do highscore thing
            finishTime.text = "Time: " + (Mathf.Round(time * 100f)/100).ToString("0.00");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            /* TO-DO:
               - Stop timer
               - Show 'end screen' that displays the player's time
               - Buttons on screen to go back to menu or go to next level
               - Only display 'next level' button if they unlocked it
                 (found all coins? got under par time?)
               - Save best player time (maybe do this somewhere else idk)
            */
        }
    }
    public void NextLevel() {
        // reset bools and timers and set cursor state to correct one
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quit() {
        Application.Quit();
    } 
    public void menu() {
        // reset bools and timers and set cursor state to correct one
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }
    public void retry() {
        // reset bools and timers and set cursor state to correct one
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
