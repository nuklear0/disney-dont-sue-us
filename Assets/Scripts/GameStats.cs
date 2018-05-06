using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour {
    [SerializeField] private GameObject playerPlatform;
    [SerializeField] private GameObject secondPhaseObjects;
    private int destroyedObjects;
    private int phase;
    private PlatformScript platScript;
	// Use this for initialization
	void Start () {
        destroyedObjects = 0;
        phase = 1;
        platScript = playerPlatform.GetComponent<PlatformScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void destroyObject()
    {
        destroyedObjects++;
    }

    public int getDestroyedObjects()
    {
        return destroyedObjects;
    }

    public int getPhase()
    {
        return phase;
    }

    public void setPhase(int p)
    {
        phase = p;
        secondPhaseObjects.SetActive(true);
    }

    public void setSecondPhaseSpeed()
    {
        platScript.setSecondPhase();
        platScript.setSpeed(5);
    }
}
