using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    private Actions actions;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawn;
    private GameObject player;
    private bool running;
    private bool dead = false;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        actions = gameObject.GetComponent<Actions>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, player.transform.position) < 15 && !running && !dead)
        {
            StartCoroutine(fire());
        }
        else
        {
            StopCoroutine(fire());
        }
        if (!dead)
        {
            transform.LookAt(player.transform);
        }
	}

    IEnumerator fire()
    {
        running = true;
        actions.Aiming();
        yield return new WaitForSeconds(0.5f);
        actions.Attack();
        spawnBullet();
        yield return new WaitForSeconds(0.5f);
        actions.Stay();
        yield return new WaitForSeconds(0.5f);
        running = false;
    }

    private void spawnBullet()
    {
        GameObject b = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("deflected"))
        {
            dead = true;
            StopCoroutine(fire());
            actions.Death();
        }
    }
}
