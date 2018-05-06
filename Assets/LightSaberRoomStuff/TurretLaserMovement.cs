using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLaserMovement : MonoBehaviour {

    [SerializeField] GameObject explosion;
    [SerializeField] GameObject physicsExplosion;
    private bool deflected = false;

    bool ready = false;
	// Use this for initialization
	void Start () {
        StartCoroutine(SelfDestruct());
        StartCoroutine(ProjectileReady());
    }
	
	// Update is called once per frame
	void Update () {
        if (!deflected)
        transform.Translate(new Vector3(0f, 0f, 7f) * Time.deltaTime);
    }

    // To avoid having turrets getting blown up from spawning a projectile
    IEnumerator ProjectileReady()
    {
        yield return new WaitForSeconds(0.5f);
        ready = true;
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Turret") && ready)
        {
            collision.gameObject.SetActive(false);
            GameObject.Find("Shooting Manager").GetComponent<ShootingManager>().ResetBulletSpawnList();
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            Destroy(gameObject);
        }
        if (collision.gameObject.name.Equals("LaserSwordHilt"))
            Destroy(gameObject);
        if (collision.gameObject.name.Contains("LaserSword"))
        {
            gameObject.GetComponent<AudioSource>().Play();
            deflected = true;
            Vector3 pos = collision.contacts[0].point;
            Instantiate(physicsExplosion, pos, new Quaternion(0, 0, 0, 0));
        }
    }
}
