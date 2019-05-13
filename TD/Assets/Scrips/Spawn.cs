using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject enermy;
    public float spawnTimer = 2f;
    public float waveWait = 1f;
    public int enermiesPerWave = 10;


    IEnumerator spawn()
    {
        WorldStats.level += 1;
        WaitForSeconds wait = new WaitForSeconds(spawnTimer);
        for (int i = 0; i < enermiesPerWave; i++)
        {
            yield return wait;
            GameObject childObject = Instantiate(enermy, gameObject.transform.position, Quaternion.identity);
            childObject.transform.parent = GameObject.Find("Enermies").transform;
        }
        yield return new WaitForSeconds(waveWait);

    }
    public void nextWave()
    {
        StartCoroutine(spawn());
    }


}
