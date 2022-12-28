using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillageItemBuy : MonoBehaviour
{
    public Button Item1;
    //public Button Item2;
    //public Button Item3;
    //public Button Item4;
    public Text Item1Price;
    // Start is called before the first frame update
    void Start()
    {
        Item1Price = Item1.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnItem1()
    {
        Item1Price.text = "80,000";
    }
}
