using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public bool move;
    public float speed;

	// Use this for initialization
	void Start () {
        move = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (move)
        {
            switch (gameObject.name)
            {
                case "Logo":
                    transform.Translate(Vector3.down * Time.deltaTime * speed);
                    break;
                case "Crawl":
                    transform.Translate(Vector3.back * Time.deltaTime * speed);
                    break;
                default:
                    break;

            }
        }
	}
}
