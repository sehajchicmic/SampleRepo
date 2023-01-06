using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillageShop : MonoBehaviour
{
    public VillageManager villageManager;
    public VillageUpgrade villageUpgrade;


    public GameObject prefab;
    public Transform parent;
    //int currentUpgradeLevel = 0;
    //int currentDestroyLevel;
    List<GameObject> currentShopPrefabs;
    

    public GameObject villageShop;
    // Start is called before the first frame update
    void Start()
    {
        currentShopPrefabs = new List<GameObject>();
    }

    #region Village Shop

    public void ShopInstantiate()
    {
        villageShop.SetActive(true);
        for (int i = 0; i < villageManager.currentVillage.items.Length; i++)
        {
            if (villageManager.currentDestroyLevel[i] == 0)
            {
                UpgradeItem(i);
            }
            else
            {
                FixItem(i);
            }
        }
    }

    public void CloseShop()
    {
        foreach (GameObject gameObject in currentShopPrefabs)
        {
            Destroy(gameObject);
        }
        villageShop.SetActive(false);
        currentShopPrefabs.Clear();
    }

    #region Upgrade Items in Village Shop
    public void UpgradeItem(int i)
    {
        GameObject item = Instantiate(prefab, parent);

        item.GetComponent<ItemReference>().itemImageCurrentLevel.sprite = villageManager.currentVillage.items[i].upgradeLevel[villageManager.itemsUpgradeLevel[i]].upgradeItem;
        if (villageManager.itemsUpgradeLevel[i] + 1 != villageManager.currentVillage.items[i].upgradeLevel.Length)
        {
            item.GetComponent<ItemReference>().itemImageNextLevel.sprite = villageManager.currentVillage.items[i].upgradeLevel[villageManager.itemsUpgradeLevel[i] + 1].upgradeItem;
        }
        else
        {
            item.GetComponent<ItemReference>().updateButton.enabled = false;
            item.GetComponent<ItemReference>().itemImageNextLevel.enabled = false;
        }
        int temp = i;
        item.GetComponent<ItemReference>().updateButton.onClick.AddListener(delegate { onClickUpgrade(temp, item); });
        currentShopPrefabs.Add(item);
    }
    public void onClickUpgrade(int itemIndex, GameObject item)
    {
        villageManager.itemsUpgradeLevel[itemIndex] += 1;
        //Debug.Log($"{villageManager.itemsUpgradeLevel[itemIndex]}");
        item.GetComponent<ItemReference>().itemImageCurrentLevel.sprite = villageManager.currentVillage.items[itemIndex].upgradeLevel[villageManager.itemsUpgradeLevel[itemIndex]].upgradeItem;
        if (villageManager.itemsUpgradeLevel[itemIndex] + 1 >= villageManager.currentVillage.items[itemIndex].upgradeLevel.Length)
        {
            Debug.Log("Completed");
            item.GetComponent<ItemReference>().updateButton.enabled = false;
            item.GetComponent<ItemReference>().itemImageNextLevel.enabled = false;
        }
        else
        {
            item.GetComponent<ItemReference>().itemImageNextLevel.sprite = villageManager.currentVillage.items[itemIndex].upgradeLevel[villageManager.itemsUpgradeLevel[itemIndex] + 1].upgradeItem;
        }
        //Debug.Log(itemIndex);
        villageUpgrade.InstatiateItem(itemIndex);
        CloseShop();
    }
    
    #endregion

    #region Fix Items in Village Shop
    public void FixItem(int i)
    {
        GameObject item = Instantiate(prefab, parent);
        currentShopPrefabs.Add(item);
        item.GetComponent<ItemReference>().itemImageCurrentLevel.sprite = villageManager.currentVillage.items[i].upgradeLevel[i].destroyLevel[villageManager.currentDestroyLevel[i]].destroyItem;//currentVillage.items [ i ].upgradeLevel[currentUpgradeLevel].destroyLevel[currentDestroyLevel].destroyItem;
        if (villageManager.currentDestroyLevel[i] == 1)
        {
            item.GetComponent<ItemReference>().itemImageNextLevel.enabled = false;
        }
        else
        {
            item.GetComponent<ItemReference>().itemImageNextLevel.sprite = villageManager.currentVillage.items[i].upgradeLevel[i].destroyLevel[villageManager.currentDestroyLevel[i] - 1].destroyItem;
        }
        int temp = i;
        item.GetComponent<ItemReference>().buttonText.text = "fix";
        item.GetComponent<ItemReference>().updateButton.onClick.AddListener(delegate { onClick(item, temp); });
    }
    private void onClick(GameObject item, int itemIndex)
    {
        
        villageManager.currentDestroyLevel[itemIndex] -= 1;
        if(villageManager.currentDestroyLevel[itemIndex] == 0)
        {
            villageUpgrade.InstatiateItem(itemIndex);
            item.GetComponent<ItemReference>().updateButton.enabled = false;
        }
        else if(villageManager.currentDestroyLevel[itemIndex] == 1)
        {
            item.GetComponent<ItemReference>().itemImageCurrentLevel.sprite = villageManager.currentVillage.items[itemIndex].upgradeLevel[villageManager.itemsUpgradeLevel[itemIndex]].destroyLevel[villageManager.currentDestroyLevel[itemIndex]].destroyItem;
            item.GetComponent<ItemReference>().itemImageNextLevel.enabled = false;
            villageUpgrade.InstatiateItem(itemIndex);
        }
        else
        {
            item.GetComponent<ItemReference>().itemImageCurrentLevel.sprite = villageManager.currentVillage.items[itemIndex].upgradeLevel[villageManager.itemsUpgradeLevel[itemIndex]].destroyLevel[villageManager.currentDestroyLevel[itemIndex]].destroyItem;
            item.GetComponent<ItemReference>().itemImageNextLevel.sprite = villageManager.currentVillage.items[itemIndex].upgradeLevel[villageManager.itemsUpgradeLevel[itemIndex]].destroyLevel[villageManager.currentDestroyLevel[itemIndex]-1].destroyItem;
            villageUpgrade.InstatiateItem(itemIndex);
        }
        CloseShop();
    }
    #endregion
    #endregion Village Shop
}
