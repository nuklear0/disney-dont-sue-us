using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JTBulletMovement : MonoBehaviour {

    [SerializeField] GameObject explosion;
    [SerializeField] GameObject physicsExplosion;
    private bool deflected = false;
    private Vector3 direction;
    bool ready = false;
    // Use this for initialization
    void Start()
    {
        direction = new Vector3(0f, -7f, 0f);
        StartCoroutine(SelfDestruct());
        StartCoroutine(ProjectileReady());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
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

    private void OnTriggerEnter(Collider collision)
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
            //RaycastHit hit;
            //if (Physics.Raycast(transform.position, transform.forward, out hit))
            //{
            //    Vector3 pos = hit.point;
            //    Instantiate(physicsExplosion, pos, new Quaternion(0, 0, 0, 0));
            //}
            direction = new Vector3(0f, 7f, 0f);
            this.gameObject.tag = "deflected";
            this.gameObject.layer = 0;
        }
    }
}
