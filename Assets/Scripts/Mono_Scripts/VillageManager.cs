using System;
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
    public int currentVillagenumber = 0;
    Village currentVillage;
    List<int> itemsUpgradeLevel = new List<int>() { 0, 0, 0, 0, 0 };

    public GameObject fixPrefab;
    public Transform fixParent;
    int currentUpgradeLevel=0;
    //int currentDestroyLevel;

    List<int> currentDestroyLevel=new List<int> { 4,4,4,4,4};





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
        LoadVillage();
        //GenerateItem();
        //fix ();
    }

    private void Init()
    {
        villages = new List<Village>();
    }

    #region Village

    public Image villageImage;
    public Image itemImage;
    public void LoadVillage()
    {
        currentVillage = data_SO.villageList[currentVillagenumber];
        villageImage.sprite = currentVillage.villageSprite;
        UpgradeItem();
    }
    public void UpgradeItem()
    {
        itemsUpgradeLevel[0] += 1;
        itemImage.sprite = currentVillage.items[0].upgradeLevel[itemsUpgradeLevel[0]].upgradeItem;
    }
    public void DestroyItem()
    {

    }
    #endregion

    #region Upgrade Items in Village Shop
    public void GenerateItem()
    {
        for (int i = 0; i < currentVillage.items.Length; i++)
        {
            GameObject item = Instantiate(prefab, parent);
            item.GetComponent<ItemReference>().itemImageCurrentLevel.sprite = currentVillage.items[i].upgradeLevel[itemsUpgradeLevel[i]].upgradeItem;
            item.GetComponent<ItemReference>().itemImageNextLevel.sprite = currentVillage.items[i].upgradeLevel[itemsUpgradeLevel[i] + 1].upgradeItem;
            int temp = i;
            item.GetComponent<ItemReference>().updateButton.onClick.AddListener(delegate { onClickUpgrade(temp, item); });
        }
    }
    public void onClickUpgrade(int itemIndex, GameObject item)
    {
        //Debug.Log($"onClicked Pressed {itemIndex} { itemsUpgradeLevel.Count}");
        itemsUpgradeLevel[itemIndex] += 1;
        Debug.Log($"{itemsUpgradeLevel[itemIndex]}");
        item.GetComponent<ItemReference>().itemImageCurrentLevel.sprite = currentVillage.items[itemIndex].upgradeLevel[itemsUpgradeLevel[itemIndex]].upgradeItem;
        if (itemsUpgradeLevel[itemIndex] + 1 == currentVillage.items[itemIndex].upgradeLevel.Length)
        {
            Debug.Log("Completed");
            item.GetComponent<ItemReference>().updateButton.enabled = false;
            item.GetComponent<ItemReference>().itemImageNextLevel.enabled = false;
        }
        else
        {
            item.GetComponent<ItemReference>().itemImageNextLevel.sprite = currentVillage.items[itemIndex].upgradeLevel[itemsUpgradeLevel[itemIndex] + 1].upgradeItem;
        }
    }
    public void UpgradeLevel()
    {

    }
    #endregion

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
    //public void Attack () {
    //    currentVillage.items [ currentVillagenumber-1 ].upgradeLevel [ currentUpgradeLevel ].upgradeItem = currentVillage.items [ currentVillagenumber-1 ].upgradeLevel [ currentUpgradeLevel ].destroyLevel [ currentDestroyLevel + 1 ].destroyItem;
    //    currentDestroyLevel += 1;
    //    prefab.GetComponentInChildren<Button> ().GetComponentInChildren<Text> ().text = "fix";
    //}
    #region item fix
    public void fix () {
        for ( int i = 0; i < currentVillage.items.Length; i++ ) {
            GameObject item = Instantiate ( fixPrefab, fixParent );
            currentUpgradeLevel = item.GetComponent<ItemReference> ().currentUpgradeLevel;
            currentDestroyLevel [i] = item.GetComponent<ItemReference> ().currentDestroyLevel;
            item.GetComponent<ItemReference> ().itemImageCurrentLevel.sprite = currentVillage.items [ 0 ].upgradeLevel [ i ].destroyLevel [ currentDestroyLevel[i] ].destroyItem;//currentVillage.items [ i ].upgradeLevel[currentUpgradeLevel].destroyLevel[currentDestroyLevel].destroyItem;
            item.GetComponent<ItemReference> ().itemImageNextLevel.sprite = currentVillage.items [ 0 ].upgradeLevel [ i ].destroyLevel [ currentDestroyLevel[i] - 1 ].destroyItem;
            int temp = i; 
            item.GetComponent<ItemReference> ().buttonText.text = "fix";
            item.GetComponent<ItemReference> ().updateButton.onClick.AddListener ( delegate { onClick (item,temp); } );
        }
    }
    private void onClick (GameObject item,int temp) {
        if ( currentDestroyLevel[temp] <= 0 ) {
            item.GetComponent<ItemReference> ().updateButton.enabled = false;
            return;
        }
        Debug.Log ( "onClick called" );
        item.GetComponent<ItemReference> ().itemImageCurrentLevel.sprite = currentVillage.items [ 0 ].upgradeLevel [ currentUpgradeLevel ].destroyLevel [ currentDestroyLevel[temp]-1 ].destroyItem;
        if ( currentDestroyLevel[temp] <= 1 ) {
            item.GetComponent<ItemReference> ().itemImageNextLevel.enabled = false;
        } else {
            item.GetComponent<ItemReference> ().itemImageNextLevel.sprite = currentVillage.items [ 0 ].upgradeLevel [ currentUpgradeLevel ].destroyLevel [ currentDestroyLevel[temp] - 2 ].destroyItem;
        }
        currentDestroyLevel[temp] -= 1;
        Debug.Log ( $"Current Destroy Level:-{currentDestroyLevel[temp]+1}" );
    }
    #endregion
}