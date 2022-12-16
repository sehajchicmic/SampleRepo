using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamePanelLoader : MonoBehaviour
{
    public GameObject gameScreenPanel;
    public GameObject homeScreenPanel;
    public GameObject buttonPanel;
    //public Toggle cards2;
    //public Toggle cards4;
    //public GameObject cards2;
    //public GameObject cards4;
    //public GameObject cards6;
    //public GameObject cards8;
    //public cardManager card;

    public void Start()
    {
        //card = GameObject.FindObjectOfType<cardManager>().GetComponent<cardManager>();
       // card.test();
    }

    //public void Update()
    //{
        
    //}

    //public void activeToggle()
    //{
    //    if(cards2.isOn)
    //    {
    //        Debug.
    //    }
    //}

    public void LoadScene()
    {
        //Debug.Log("Hello");
        homeScreenPanel.SetActive(false);
        gameScreenPanel.SetActive(true);
        buttonPanel.SetActive(false);
    }
}
