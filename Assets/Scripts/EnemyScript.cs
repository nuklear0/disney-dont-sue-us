using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    private Actions actions;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawn;
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        actions = gameObject.GetComponent<Actions>();
        StartCoroutine(fire());
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player.transform);
	}

    IEnumerator fire()
    {
        actions.Walk();
        yield return new WaitForSeconds(2f);
        actions.Aiming();
        yield return new WaitForSeconds(2f);
        actions.Attack();
        spawnBullet();
        yield return new WaitForSeconds(2f);
        actions.Jump();
        yield return new WaitForSeconds(2f);
        StartCoroutine(fire());
    }

    private void spawnBullet()
    {
        GameObject b = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        //b.transform.Rotate(new Vector3(0,0,1), 90);
    }
}
