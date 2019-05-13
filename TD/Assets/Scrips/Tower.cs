﻿using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{
    

   [Header("Attributes")]
    public float range = 400;
    public  int damage = 10;
    public float fireRate = 1;
    private float firecountdown = 0;

    [Header("Unity Setup")]
    public float turnSpeed = 10f;
    public GameObject bullet;
    public Enermy target;
    public string enermytag = "Enermy";
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("updateTarget", 0f, 0.5f);
    }

    void updateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enermytag);
        foreach ( GameObject enermy in enemies)
        {
            float distanceToTarget = Vector3.Distance(transform.position, enermy.transform.position);
            if (distanceToTarget < range)
            {
                target = enermy.GetComponent<Enermy>();
                break;
            }
            else
            {
                target = null;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        trackTarget();

        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void trackTarget()
    {
        if (target != null)
        {
            Vector3 dir = target.transform.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            var toPos = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, toPos, Time.deltaTime * turnSpeed);

            if (firecountdown <= 0)
            {
                shoot();
                firecountdown = 1f / fireRate;
            }
            firecountdown -= Time.deltaTime;
        }
    }

    void shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Bullet bulletCom = newBullet.GetComponent<Bullet>();
        newBullet.transform.parent = gameObject.transform;
        if (bulletCom != null)
        {
            bulletCom.setTarget(target);
            bulletCom.setDamage(damage);
        }
      
    }
}