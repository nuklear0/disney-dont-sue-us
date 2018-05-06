using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Back))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

    }


}
