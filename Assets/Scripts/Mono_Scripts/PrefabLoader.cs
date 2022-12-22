using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PrefabLoader : MonoBehaviour
{

    public GameObject CardPrefab1;
    //public GameObject CardPrefab2;
    public GameObject spawn;
    //public GameObject spawn2;
    public Toggle cards1;
    public Toggle cards2;
    public Toggle cards3;
    public Toggle cards4;
    public GameObject disablebutton78;
    public GameObject disablebutton56;
    public GameObject disablebutton34;
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
            temp.transform.position = new Vector3(0, 0, 0);
            disablebutton34.SetActive(false);
            disablebutton56.SetActive(false);
            disablebutton78.SetActive(false);
            //temp.Position.x = 0f;
            //temp.transform.localScale.x = 100f;

        }
        else if (cards2.isOn)
        {
            //Debug.Log("entered");
            GameObject temp = Instantiate(CardPrefab1, spawn.transform.position, Quaternion.identity);
            temp.transform.parent = spawn.transform;
            temp.transform.position = new Vector3(0, 0, 0);
            GameObject temp2= Instantiate(CardPrefab1, spawn.transform.position, Quaternion.identity);
            temp2.transform.parent = spawn.transform;
            temp2.transform.position = new Vector3(0, 0, 0);
            disablebutton56.SetActive(false);
            disablebutton78.SetActive(false);
        }
        else if(cards3.isOn)
        {
            GameObject temp = Instantiate(CardPrefab1, spawn.transform.position, Quaternion.identity);
            temp.transform.parent = spawn.transform;
            temp.transform.position = new Vector3(0, 0, 0);
            GameObject temp2 = Instantiate(CardPrefab1, spawn.transform.position, Quaternion.identity);
            temp2.transform.parent = spawn.transform;
            temp2.transform.position = new Vector3(0, 0, 0);
            GameObject temp3 = Instantiate(CardPrefab1, spawn.transform.position, Quaternion.identity);
            temp3.transform.parent = spawn.transform;
            temp3.transform.position = new Vector3(0, 0, 0);
            disablebutton78.SetActive(false);
        }
        else if (cards4.isOn)
        {
            GameObject temp = Instantiate(CardPrefab1, spawn.transform.position, Quaternion.identity);
            temp.transform.parent = spawn.transform;
            temp.transform.position = new Vector3(0, 0, 0);
            GameObject temp2 = Instantiate(CardPrefab1, spawn.transform.position, Quaternion.identity);
            temp2.transform.parent = spawn.transform;
            temp2.transform.position = new Vector3(0, 0, 0);
            GameObject temp3 = Instantiate(CardPrefab1, spawn.transform.position, Quaternion.identity);
            temp3.transform.parent = spawn.transform;
            temp3.transform.position = new Vector3(0, 0, 0);
            GameObject temp4 = Instantiate(CardPrefab1, spawn.transform.position, Quaternion.identity);
            temp4.transform.parent = spawn.transform;
            temp4.transform.position = new Vector3(0, 0, 0);
        }

        //GameObject temp = Instantiate(Card, spawn.transform.position,Quaternion.identity);
        ////temp.transform.localScale.
        //temp.transform.parent = spawn.transform;
        ////temp.Position.x = 0f;
        ////temp.transform.localScale.x = 100f;
        //Debug.Log("shut");
    }
}
