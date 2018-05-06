using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightsaber : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.Button.Down))
            this.gameObject.transform.localScale = new Vector3(1,1,0);
        if (OVRInput.Get(OVRInput.Button.Up))
            this.gameObject.transform.localScale = new Vector3(1,1,1);
    }
}
