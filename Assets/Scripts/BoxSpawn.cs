using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawn : MonoBehaviour {
    [SerializeField] private GameObject box;
    [SerializeField] private float spawnTime;
	// Use this for initialization
	void Start () {
        StartCoroutine(spawnPeriodicly());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator spawnPeriodicly()
    {
        GameObject asteroid = Instantiate(box, gameObject.transform.position, Quaternion.identity);
        asteroid.GetComponent<Rigidbody>().AddRelativeForce(gameObject.transform.up * 50f, ForceMode.Impulse);
        Destroy(asteroid, 5f);
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(spawnPeriodicly());
    }
}
