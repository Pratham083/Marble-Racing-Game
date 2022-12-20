using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{

    public int countdownTime;
    public TMPro.TextMeshProUGUI countdownDisplay;

    public GameObject Ball;
    MarbleController script;
    TimerController scriptB;

    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay.text = "Go!";

        // enable movement
        script.enabled = true;

        TimerController.instance.BeginTimer();

        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        script = Ball.GetComponent<MarbleController>();

        // disable movement
        script.enabled = false;

        StartCoroutine(CountdownToStart());
    }
}
