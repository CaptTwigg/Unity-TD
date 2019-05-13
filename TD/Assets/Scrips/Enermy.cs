using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enermy : MonoBehaviour
{

    public float speed = 100f;
    public int hp = 100;
    public int gold = 10;
    public GameObject healthBar;
    private Transform target;
    private int wavePointIndex = 0;


    // Use this for initialization
    void Start()
    {
        target = Waypoints.points[wavePointIndex];
        hp += Mathf.RoundToInt(WorldStats.level * .1f * hp);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //Debug.Log(Vector3.Distance(target.position, transform.position));
        if (Vector3.Distance(target.position, transform.position) < 4f)
        {
            if (wavePointIndex == Waypoints.points.Length-1)
            {
                WorldStats.HP -= 1;
                Destroy(gameObject);
            }
            else
            {
                wavePointIndex++;
                target = Waypoints.points[wavePointIndex];
            }

        }
        if (hp <= 0)
        {
            WorldStats.gold += gold;
            Destroy(gameObject);
        }
    }
    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
    }
}
