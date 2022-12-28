using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;


[CreateAssetMenu(fileName = "NewVillage", menuName ="Villages")]
public class VillageData_SO : ScriptableObject
{
    //public Sprite village1;
    [SerializeField]
    public  List<Village> villageList;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
