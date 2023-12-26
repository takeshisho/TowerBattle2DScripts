using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] CustomButton pauseButton;
    [SerializeField] CustomButton resumeButton;

    void Start()
    {
        pausePanel.SetActive(false);
        pauseButton.onClickCallback = Pause;
        resumeButton.onClickCallback = Resume;
    }

    private void Pause()
    {
        // timeScale: 時間の流れの速さを決める。1で通常速度、0で停止
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    private void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
