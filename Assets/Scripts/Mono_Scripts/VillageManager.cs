using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VillageManager : MonoBehaviour
{
    public VillageUpgrade villageUpgrade;
    public VillageShop villageShop;
    public Image VillagePrefab;
    public Transform content;
    //public GameObject contentView;
    public Sprite lockedVillageImage;
    public Sprite unlockedVillageImage;


    public List<Village> villages;
    
    public VillageData_SO data_SO;
    public int currentVillagenumber = 0;
    public Village currentVillage;

    public Image villageImage;
    public Image itemImage;
    public List<int> itemsUpgradeLevel = new List<int>() { 0, 0, 0, 0, 0 };
    public List<int> currentDestroyLevel = new List<int> { 0, 0, 0, 4, 4 };


    public void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        //int i1 = data_SO.villageList [ 0 ].items.Length;
        ////currentDestroyLevel = new List<int> (i1);
        //for ( int i = 0; i <= i1; i1++ ) {
        //    currentDestroyLevel.Add ( i1 );
        //}
        Init ();
        //LoadImageMap();
        
        //GenerateItem();
        //fix ();
    }

    private void Init()
    {
        villages = new List<Village>();
        villages = data_SO.villageList;
        LoadImageMap();
    }

   

   

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void LoadImageMap()
    {
        foreach (Village v in villages)
        {
            Image village = Instantiate(VillagePrefab,content.transform);
            village.sprite = v.villageMapSprite;

            //if (!v.isLocked)
            //{
            //    village.sprite = unlockedVillageImage;
            //}

        }
    }
    public void Attack(int itemIndex)
    {
        Debug.Log($"{itemIndex} {currentDestroyLevel.Count}");
        if (currentDestroyLevel[itemIndex] != 4)
        {
            currentDestroyLevel[itemIndex] += 1;
        }
        //foreach(Image item in villageUpgrade.currentItems)
        //{
        //    Destroy(item.gameObject);
        //}
        //villageUpgrade.currentItems.Clear();
        Image image = villageUpgrade.currentItems[itemIndex];
        Destroy(image.gameObject);

        Image item = Instantiate(itemImage, villageImage.transform);
        item.transform.localPosition = currentVillage.items[itemIndex].spawnPoint;
        if (currentDestroyLevel[itemIndex] == 0)
        {
            item.sprite = currentVillage.items[itemIndex].upgradeLevel[itemsUpgradeLevel[itemIndex]].upgradeItem;
        }
        else
        {
            item.sprite = currentVillage.items[itemIndex].upgradeLevel[itemsUpgradeLevel[itemIndex]].destroyLevel[currentDestroyLevel[itemIndex]].destroyItem;
        }
        int index = itemIndex;
        villageUpgrade.currentItems[itemIndex] = item;

        item.GetComponentInChildren<Button>().onClick.AddListener(delegate { Attack(index); });

        //villageUpgrade.LoadVillage();
    }
}