using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VillageManager : MonoBehaviour
{
    public Image VillagePrefab;
    public Transform content;
    //public GameObject contentView;
    public Sprite lockedVillageImage;
    public Sprite unlockedVillageImage;


    public List<Village> villages;
    public GameObject prefab;
    public Transform parent;
    public VillageData_SO data_SO;
    public int currentVillagenumber = 1;
    Village currentVillage;



    public void Awake()
    {   
    }


    // Start is called before the first frame update
    void Start()
    {
        Init();
        //LoadImageMap();
        LoadVillage();
        GenerateItem();
    }

    private void Init()
    {
        villages = new List<Village>();
    }

    public void LoadVillage()
    {
        currentVillage = data_SO.villageList[currentVillagenumber - 1];
    }
    public void GenerateItem()
    {
        for (int i = 0; i < currentVillage.items.Length; i++)
        {
            GameObject item = Instantiate(prefab, parent);
            item.GetComponent<ItemReference>().itemImage.sprite = currentVillage.items[i].itemSprite;
        }
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    void LoadImageMap()
    {
        foreach (Village v in villages)
        {
            Image village = Instantiate(VillagePrefab, new Vector3(0, 0, 0), Quaternion.identity, content.transform);
            village.sprite = lockedVillageImage;

            if (!v.isLocked)
            {
                village.sprite = unlockedVillageImage;
            }

        }
    }
}
