using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JTPlayerMovement : MonoBehaviour {

    [SerializeField] private float speed;
    private JTLevelLoad loadScript;
    private int[] directions;
    private Vector3[] positions;
    private int currentPosition = 0;
    private Vector3 movingVector;
    private GameManager gm;
    private AudioSource[] audio;
	// Use this for initialization
	void Start () {
        loadScript = GameObject.FindGameObjectWithTag("level").GetComponent<JTLevelLoad>();
        createDirectionArray();
        createPositionArray();
        movingVector = getCurrentVector();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        audio = gm.GetComponents<AudioSource>();
        audio[2].Play();
        Physics.IgnoreLayerCollision(0, 9);
        Physics.IgnoreLayerCollision(8, 9);
    }
	
	// Update is called once per frame
	void Update () {
        if (currentPosition < directions.Length-1)
        {
            transform.Translate(movingVector * speed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(restart());
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

    IEnumerator restart()
    {
        audio[1].Stop();
        yield return new WaitForSeconds(1f);
        audio[2].Play();
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene(0);
    }
}
