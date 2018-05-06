using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    GameObject[] enemies;
    Boolean isCoroutineRunning = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isCoroutineRunning && SceneManager.GetActiveScene().buildIndex != 3)
        {
            isCoroutineRunning = true;
            //StartCoroutine(Shoot());
        }
        if (OVRInput.GetDown(OVRInput.Button.Back) || Input.GetKey("b"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

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

    public void playDamageSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
