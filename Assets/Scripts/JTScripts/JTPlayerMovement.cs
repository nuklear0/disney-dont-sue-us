using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JTPlayerMovement : MonoBehaviour {

    [SerializeField] private float speed;
    private JTLevelLoad loadScript;
    private int[] directions;
    private Vector3[] positions;
    private int currentPosition = 0;
    private Vector3 movingVector;
    private GameManager gm;
	// Use this for initialization
	void Start () {
        loadScript = GameObject.FindGameObjectWithTag("level").GetComponent<JTLevelLoad>();
        createDirectionArray();
        createPositionArray();
        movingVector = getCurrentVector();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Physics.IgnoreLayerCollision(0, 9);
        Physics.IgnoreLayerCollision(8, 9);
    }
	
	// Update is called once per frame
	void Update () {
        if (currentPosition < directions.Length-1)
        {
            transform.Translate(movingVector * speed * Time.deltaTime);
        }
	}

    public void setSpeed(float s)
    {
        speed = s;
    }
    private void createDirectionArray()
    {
        directions = loadScript.getDirections();
    }

    private void createPositionArray()
    {
        positions = loadScript.getPositions();
    }
    private Vector3 getCurrentVector()
    {
        switch (directions[currentPosition])
        {
            case 0:
                return Vector3.forward;
            case 1:
                return Vector3.right;
            case 2:
                return Vector3.left;
            default:
                return Vector3.forward;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("block"))
        {
            StartCoroutine(turningDelay());
        }
    }

    IEnumerator turningDelay()
    {       
        yield return new WaitForSeconds(0.875f/speed);
        currentPosition++;
        movingVector = getCurrentVector();
    }
}
