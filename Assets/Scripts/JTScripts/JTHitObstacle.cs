using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JTHitObstacle : MonoBehaviour {
    private GameManager gm;
	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();
        Physics.IgnoreLayerCollision(8,11);
        Physics.IgnoreLayerCollision(9,11);
        Physics.IgnoreLayerCollision(0,11);
        Physics.IgnoreLayerCollision(10, 10);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("box"))
        {
            Debug.Log("FUCK");
            gm.playDamageSound();
        }
    }
}
