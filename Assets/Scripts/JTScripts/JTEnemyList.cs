using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JTEnemyList : MonoBehaviour {
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] obstacles;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject chooseEnemy()
    {
        return enemies[Random.Range(0, enemies.Length)];
    }

    public GameObject chooseObstacle()
    {
        return obstacles[Random.Range(0, obstacles.Length)];
    }
}
