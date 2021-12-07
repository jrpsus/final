using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            //unpause
            Time.timeScale = 1.0f;
        }
        else
        {
            //pause
            Time.timeScale = 0.0f;
        }
        isPaused = !isPaused;
    }
}
