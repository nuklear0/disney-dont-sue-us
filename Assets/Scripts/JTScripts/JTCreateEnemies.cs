using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JTCreateEnemies : MonoBehaviour {
    private GameObject enemy;
    private GameObject obstacle;
    private bool hasEnemy;
    private bool hasObstacle;
    private List<Transform> spawnPoints;
	// Use this for initialization
	void Start () {
        spawnPoints = new List<Transform>();
        randomNumber();
        shouldItHaveObstacle();
        hasEnemy = true;
        if (hasEnemy)
        {
            chooseEnemy();
            fillSpawnPoints();
            if(spawnPoints.Capacity > 0)
            {
                spawnEnemy();
            }
        }
        if (hasObstacle)
        {
            chooseObstacle();
            spawnObstacle();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void randomNumber()
    {
        hasEnemy = Random.Range(0, 3) == 0 ? true : false;
    }

    void shouldItHaveObstacle()
    {
        hasObstacle = Random.Range(0, 5) == 3 && !hasEnemy? true : false;
    }

    void fillSpawnPoints()
    {
        foreach (Transform tr in gameObject.GetComponentsInChildren<Transform>())
        {
            if (tr.gameObject.tag.Equals("enemySpawn"))
            {
                spawnPoints.Add(tr);
            }
        }
    }

    void spawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Count);
        Instantiate(enemy, spawnPoints[spawnIndex].position, Quaternion.identity);
    }

    void spawnObstacle()
    {
        foreach (Transform tr in gameObject.GetComponentsInChildren<Transform>())
        {
            if (tr.gameObject.name.Equals("ObstacleSpawn"))
            {
                Instantiate(obstacle, tr.position, Quaternion.identity);
            }
        }
    }

    void chooseEnemy()
    {
        enemy = GameObject.FindGameObjectWithTag("EnemyList").GetComponent<JTEnemyList>().chooseEnemy();
    }

    void chooseObstacle()
    {
        obstacle = GameObject.FindGameObjectWithTag("EnemyList").GetComponent<JTEnemyList>().chooseObstacle();
    }
}
