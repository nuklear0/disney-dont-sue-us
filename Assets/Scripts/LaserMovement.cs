using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserMovement : MonoBehaviour {

    private GameObject wayPoint;
    private Vector3 wayPointPos;
    // Use this for initialization
    void Start ()
    {
        wayPoint = GameObject.Find("Player");
        wayPointPos = new Vector3(0, 1, 0);

    }
	
	// Update is called once per frame
	void Update ()
    {
        wayPointPos = new Vector3(0, 2, 0);
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, 3.5f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("LightSaberBlade"))
        {
            StartCoroutine(DestroyLaser());
        }
    }

    IEnumerator DestroyLaser()
    {
        float lengthOfAudio = gameObject.GetComponent<AudioSource>().clip.length;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(lengthOfAudio);
        Destroy(gameObject);
    }

}
