using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserShoot : MonoBehaviour
{
    public GameObject laser;


    void Start()
    {
    }

    public void ShootLaser()
    {
        Instantiate(laser, gameObject.transform);
    }

}
