using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroGameManager : MonoBehaviour {

    GameObject menuStuff;
    GameObject introStuff;
    GameObject logo;
    GameObject crawl;
    GameObject galaxy;
    GameObject tutorial;
    GameObject musicBox;
    float opacity;
    bool fadeout;

	// Use this for initialization
	void Start () {
        menuStuff = GameObject.Find("MenuStuff");
        introStuff = GameObject.Find("IntroStuff");
        galaxy = GameObject.Find("Galaxy");
        logo = GameObject.Find("Logo");
        crawl = GameObject.Find("Crawl");
        tutorial = GameObject.Find("Tutorial");
        musicBox = GameObject.Find("MusicBox");

        if (PlayerPrefs.GetInt("playedIntro") == 0) {
            tutorial.SetActive(false);
            menuStuff.SetActive(false);
            StartCoroutine(Intro());
        }
        else
        {
            introStuff.SetActive(false);
            menuStuff.SetActive(true);
            PlayerPrefs.SetInt("playedIntro", 1);
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (logo.transform.position.z >= 18)
            logo.SetActive(false);

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKey("p"))
        {
            introStuff.SetActive(false);
            menuStuff.SetActive(true);
        }
    }
    
    IEnumerator Intro()
    {
        yield return new WaitForSeconds(4);
        galaxy.SetActive(false);
        yield return new WaitForSeconds(1);
        musicBox.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        logo.GetComponent<Move>().move = true;
        yield return new WaitForSeconds(5);
        crawl.GetComponent<Move>().move = true;
        yield return new WaitForSeconds(60);
        crawl.SetActive(false);
        tutorial.SetActive(true);
        PlayerPrefs.SetInt("playedIntro", 1);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

    private void OnApplicationPause(bool pause)
    {
        PlayerPrefs.DeleteAll();
    }
}
