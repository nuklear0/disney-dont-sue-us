using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForcePush : MonoBehaviour {
    private MeshCollider col;
    private List<GameObject> pushableObjects;
    private List<GameObject> pullableObjects;
    [SerializeField] private GameObject weapon;
    private States states;
    private AudioScript audioScript;
    private bool looping = false;
	// Use this for initialization
	void Start () {
        col = gameObject.GetComponent<MeshCollider>();
        pushableObjects = new List<GameObject>();
        pullableObjects = new List<GameObject>();
        states = gameObject.GetComponentInParent<States>();

        if (SceneManager.GetActiveScene().buildIndex != 3)
            audioScript = GameObject.FindGameObjectWithTag("gameManager").GetComponent<AudioScript>();
    }
	
	// Update is called once per frame
	void Update () {
        if (states.getCurrentState().Equals("FORCE"))
        {
            //if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad) || Input.GetKey("k"))
            //{
            //    foreach (GameObject obj in pullableObjects)
            //    {
            //        Vector3 tempVector = calculateVector(obj.transform.position);
            //        if (obj.GetComponent<BoxCollider>() != null && obj.GetComponent<BoxCollider>().bounds.Intersects(col.bounds)
            //            && tempVector.magnitude > 0.01)
            //        {
            //            obj.GetComponent<Rigidbody>().AddForce(tempVector.normalized * 50);
            //        }
            //    }
            //}else 
            if (OVRInput.GetDown(OVRInput.Button.Up) || Input.GetKeyDown("space"))
            {
                Debug.Log(pushableObjects.Count);
                foreach (GameObject obj in pushableObjects)
                {
                    if (obj.GetComponent<Collider>() != null && obj.GetComponent<Collider>().bounds.Intersects(col.bounds))
                    {
                        obj.GetComponent<Rigidbody>().velocity = new Vector3();
                        obj.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 2000);
                    }
                }
                pushableObjects.Clear();
            }
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("box") && !looping)
        {
            pushableObjects.Add(other.gameObject);
        }
        else if (other.gameObject.tag.Equals("pullable"))
        {
            pullableObjects.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("box"))
        {
            pushableObjects.Remove(other.gameObject);
        }
        else if (other.gameObject.tag.Equals("pullable"))
        {
            pullableObjects.Add(other.gameObject);
        }
    }
    private Vector3 calculateVector(Vector3 vect)
    {
        return new Vector3(
                            weapon.transform.position.x - vect.x,
                            weapon.transform.position.y - vect.y,
                            weapon.transform.position.z - vect.z);
    }
}
