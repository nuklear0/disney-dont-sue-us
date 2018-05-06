using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

    [SerializeField] private GameObject explosion;
    private AudioScript audioScript;
    private GameStats gameStats;
    private bool secondPhase = false;

	// Use this for initialization
	void Start () {
        audioScript = GameObject.FindGameObjectWithTag("gameManager").GetComponent<AudioScript>();
        gameStats = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameStats>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Contains("Asteroid"))
        {
            StartCoroutine(respawnTarget(collider.gameObject));
        }
    }

    IEnumerator respawnTarget(GameObject asteroid)
    {
        foreach (MeshRenderer mr in gameObject.GetComponentsInChildren<MeshRenderer>())
            mr.enabled = false;
        explosion.SetActive(true);
        Destroy(asteroid);
        audioScript.playDestroySound();
        gameStats.destroyObject();
        if(gameStats.getDestroyedObjects() > 3 && gameStats.getPhase() == 1)
        {
            gameStats.setSecondPhaseSpeed();
            gameStats.setPhase(2);
            audioScript.playDuelOfFates();
        }

        yield return new WaitForSeconds(5);

        foreach (MeshRenderer mr in gameObject.GetComponentsInChildren<MeshRenderer>())
            mr.enabled = true;
        explosion.SetActive(false);
    }
}
