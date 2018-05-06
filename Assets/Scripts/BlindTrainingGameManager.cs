using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BlindTrainingGameManager: MonoBehaviour
{

    GameObject[] enemies;
    Boolean isCoroutineRunning = false;
    float opacity = 0.0f;
    GameObject curtain;

    // Use this for initialization
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        curtain = GameObject.Find("Curtain");
        var col = curtain.GetComponent<Renderer>().material.color;
        col.a = 0.0f;
        curtain.GetComponent<Renderer>().material.color = col;
    }

    // Update is called once per frame
    void Update()
    {
            if (!isCoroutineRunning)
            {
                isCoroutineRunning = true;
                StartCoroutine(Shoot());
            }
            opacity += 0.03f * Time.deltaTime;
            var col = curtain.GetComponent<Renderer>().material.color;
            col.a = opacity;
            curtain.GetComponent<Renderer>().material.color = col;

    }


    IEnumerator Shoot()
    {
        int enemyNumber = UnityEngine.Random.Range(0, enemies.Length);
        GameObject activeEnemy = enemies[enemyNumber];
        activeEnemy.GetComponent<AudioSource>().Play();
        float lengthOfAudio = activeEnemy.GetComponent<AudioSource>().clip.length;
        yield return new WaitForSeconds(lengthOfAudio);
        activeEnemy.GetComponent<EnemyLaserShoot>().ShootLaser();
        yield return new WaitForSeconds(UnityEngine.Random.Range(1, 4));
        isCoroutineRunning = false;
    }


}
