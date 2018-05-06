using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {
    private AudioSource[] audioSource;
    private bool restart = false;
	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void playBackgroundMusic()
    {
        audioSource[0].Play();
    }

    public void playForcePushSound()
    {
        if (!audioSource[1].isPlaying)
        {
            audioSource[1].Play();
        }
    }

    public void playDestroySound()
    {
        audioSource[2].Play();
    }

    public void playDarthVaderBreath()
    {
        audioSource[3].Play();
    }

    public void playDuelOfFates()
    {
        audioSource[0].Stop();
        audioSource[4].Play();
    }

    public void playHighGround()
    {
        audioSource[5].Play();
    }
}
