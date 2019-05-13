using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Enermy target;
    public float bulletSpeed = 10f;
    private int damage;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;

        if (Vector3.Distance(target.transform.position, transform.position) < 100f)
        {
            target.hp -= damage;
            Destroy(gameObject);
        }

        transform.Translate(dir.normalized * bulletSpeed, Space.World);

    }

    public void setTarget(Enermy target)
    {
        this.target = target;
    }

    public void setDamage(int damage)
    {
        this.damage = damage;
    }
}
