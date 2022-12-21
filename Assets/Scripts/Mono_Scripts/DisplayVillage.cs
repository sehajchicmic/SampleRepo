using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayVillage : MonoBehaviour
{
    public VillageData villagedata;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(villagedata.name);
    }


}
