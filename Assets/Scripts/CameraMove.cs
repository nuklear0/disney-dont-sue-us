using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VR;

public class CameraMove : MonoBehaviour {

    [SerializeField] private float moveSpeed;
    public Transform vrCamera;
    private Quaternion rot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKey(KeyCode.DownArrow)) 
            && SceneManager.GetActiveScene().buildIndex == 0 && PlayerPrefs.GetInt("playedIntro") == 1)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            transform.Translate(forward * moveSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 20 * Time.deltaTime * moveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -20 * Time.deltaTime * moveSpeed, 0);
        }
    }
}
