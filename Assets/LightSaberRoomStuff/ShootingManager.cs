using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingManager : MonoBehaviour {
    
    GameObject[] bulletSpawns;
    [SerializeField] GameObject laserProjectile;
    [SerializeField] GameObject player;
    [SerializeField] Text text;
    System.Random random = new System.Random();
    bool noCoroutinesRunning = true;

    // Use this for initialization
    void Start () {
        bulletSpawns = GameObject.FindGameObjectsWithTag("bulletspawn");
        foreach (GameObject bulletSpawn in bulletSpawns)
            bulletSpawn.transform.LookAt(player.transform);
        text.text = "Turrets remaining: " + bulletSpawns.Length;
	}
	
	// Update is called once per frame
	void Update () {
        if (noCoroutinesRunning)
        StartCoroutine(FireNextTurret());
    }

    public void ResetBulletSpawnList()
    {
        bulletSpawns = GameObject.FindGameObjectsWithTag("bulletspawn");
        text.text = "Turrets remaining: " + bulletSpawns.Length;
        if (bulletSpawns.Length == 0)
            text.text = "All turrets destroyed. Congratulations!";
    }

    void Fire(GameObject bulletSpawn)
    {
        Instantiate(laserProjectile, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        laserProjectile.transform.LookAt(player.transform);
    }

    IEnumerator FireNextTurret()
    {
        noCoroutinesRunning = false;
        Fire(bulletSpawns[random.Next(bulletSpawns.Length)]);
        yield return new WaitForSeconds(1);
        noCoroutinesRunning = true;
    }
}
