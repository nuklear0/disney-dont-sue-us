using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : MonoBehaviour {
    private GameObject gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("gameManager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("startbox"))
        {
            if (!gameManager.GetComponents<AudioSource>()[0].isPlaying)
            {
                gameManager.GetComponent<AudioScript>().playBackgroundMusic();
            }
            foreach (GameObject p in GameObject.FindGameObjectsWithTag("platform"))
            {
                p.GetComponent<PlatformScript>().enabled = true;
            }
        }
    }
}
