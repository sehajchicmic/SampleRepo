using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PrefabLoader : MonoBehaviour
{

    public GameObject CardPrefab1;
    public GameObject CardPrefab2;
    public GameObject spawn;
    public GameObject spawn2;
    public Toggle cards1;
    public Toggle cards2;
    //public GameObject test;
    //public GameObject gameObject;

    //public void Update()
    //{
    //    activeToggle();
    //}

    //public void activeToggle()
    //{
        
    //    if (cards2.isOn)
    //    {
    //        Debug.Log("2 Cards");
    //    }
    //    else if(cards4.isOn)
    //    {
    //        Debug.Log("4 Cards");
    //    }
        
    //}

    public void LoadPrefab()
    {
        if (cards1.isOn)
        {
            GameObject temp = Instantiate(CardPrefab1, spawn.transform.position, Quaternion.identity);
            //temp.transform.localScale.
            temp.transform.parent = spawn.transform;
            //temp.Position.x = 0f;
            //temp.transform.localScale.x = 100f;
            
        }
        else if (cards2.isOn)
        {
            //Debug.Log("entered");
            GameObject temp = Instantiate(CardPrefab1, spawn.transform.position, Quaternion.identity);
            temp.transform.parent = spawn.transform;
            GameObject temp2= Instantiate(CardPrefab2, spawn2.transform.position, Quaternion.identity);
            temp2.transform.parent = spawn2.transform;
        }

        //GameObject temp = Instantiate(Card, spawn.transform.position,Quaternion.identity);
        ////temp.transform.localScale.
        //temp.transform.parent = spawn.transform;
        ////temp.Position.x = 0f;
        ////temp.transform.localScale.x = 100f;
        //Debug.Log("shut");
    }
}
