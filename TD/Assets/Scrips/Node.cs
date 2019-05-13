using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Node : MonoBehaviour
{
   public GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

     

    }
    private void OnMouseDown()
    {
        
        //Instantiate(tower, transform.position, Quaternion.identity);
        if (BuyMenuUI.show)
            BuyMenuUI.show = false;

        else { 
            BuyMenuUI.show = true;
            BuyMenuUI.node = this;
        }
    }
}
