using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public int scene;
    GameObject curtain;
    float opacity = 0.0f;
    bool fadeout = false;

    // Use this for initialization
    void Start () {
        curtain = GameObject.Find("Curtain");
        var col = curtain.GetComponent<Renderer>().material.color;
        col.a = 0.0f;
        curtain.GetComponent<Renderer>().material.color = col;
    }
	
	// Update is called once per frame
	void Update () {
        if (fadeout)
        {
            opacity += 0.8f * Time.deltaTime;
            var col = curtain.GetComponent<Renderer>().material.color;
            col.a = opacity;
            curtain.GetComponent<Renderer>().material.color = col;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            StartCoroutine(TeleportRoutine());
        }
    }

    IEnumerator TeleportRoutine()
    {
        fadeout = true;
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
