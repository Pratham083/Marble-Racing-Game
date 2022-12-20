using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
public class ChangeSens : MonoBehaviour
{
    public CinemachineFreeLook cam;
    public Slider xSensSlider;
    public Slider ySensSlider;
    private void Awake() {
        if(!PlayerPrefs.HasKey("SensX")) {
            PlayerPrefs.SetFloat("SensX", 0.5f);
        }
        if(!PlayerPrefs.HasKey("SensY")) {
            PlayerPrefs.SetFloat("SensY", 0.5f);
        }
        // do for master volume/other settings too in future
        // set cam sensitivity to the player pref
        cam.m_XAxis.m_MaxSpeed = Mathf.Pow(PlayerPrefs.GetFloat("SensX") * 13.3887f, 3);
        cam.m_YAxis.m_MaxSpeed = Mathf.Pow(PlayerPrefs.GetFloat("SensY") * 2.7144f, 3);
        // set slider to correct position
        xSensSlider.value = PlayerPrefs.GetFloat("SensX");
        ySensSlider.value = PlayerPrefs.GetFloat("SensY");
    }
    public void changeSensX(float multiplier) {
        // Default: 300 (0.5 is starting multiplier)
        cam.m_XAxis.m_MaxSpeed = Mathf.Pow(multiplier * 13.3887f, 3);
        PlayerPrefs.SetFloat("SensX", multiplier);
    }

    public void changeSensY(float multiplier) {
        // Default: 2.5 (0.5 is starting multiplier)
        cam.m_YAxis.m_MaxSpeed = Mathf.Pow(multiplier * 2.7144f, 3);
        PlayerPrefs.SetFloat("SensY", multiplier);
    }
}
