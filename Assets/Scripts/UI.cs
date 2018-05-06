using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    [SerializeField] private GameObject statesGO;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () { /*
        if (states.getCurrentState().Equals("FORCE"))
            gameObject.GetComponent<Text>().text = "Use the force";
        if(states.getCurrentState().Equals("SWORD"))
            gameObject.GetComponent<Text>().text = "Lightsaber mode";*/
        //gameObject.GetComponent<Text>().text = statesGO.GetComponent<States>().getCurrentState();
        //gameObject.GetComponent<Text>().text = GameObject.FindGameObjectWithTag("Player").transform.rotation.y.ToString();
	}
}
