using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class States : MonoBehaviour
{
    private string[] modes;
    private string currentMode;

    private void Start()
    {
        modes = new string[2];
        modes[0] = "FORCE";
        modes[1] = "SWORD";
        currentMode = modes[0];
    }

    public void changeCurrentState()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                currentMode = modes[1];
                break;
            case 1:
                currentMode = modes[1];
                break;
            case 2:
                currentMode = modes[0];
                break;
            case 3:
                if (currentMode == modes[0])
                {
                    currentMode = modes[1];
                }
                else
                {
                    currentMode = modes[0];
                }
                break;
            case 4:
                currentMode = modes[0];
                break;
        }
        
    }

    public string getCurrentState()
    {
        return currentMode;
    }
}
