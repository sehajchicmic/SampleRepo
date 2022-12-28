using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Village
{
    public Sprite villageSprite;
    public bool isLocked;
    public Village(bool isLocked)
    {
        this.isLocked = isLocked;
    }

    public VillageItems[] items;   
    //public int ShieldForVillage;
    //public bool IsShieldOn;
    //public int EnoughStarsForUnlock;
   


}
[System.Serializable]
public class VillageItems
{
    //public int Items;
    public Sprite itemSprite;
    public UpgradeItem[] upgradeLevel;
    public DestroyItem[] destroyLevel;
    //public int UpgradeLevelOfItem;
    //public bool IsItemFullyMaxed;
    //public int ItemHealth;
    //public int CoinsForItemUpgrade;
    //public int StarsAfterUpgrade;
    //public int CoinsForFixItem;



}
[System.Serializable]
public class UpgradeItem
{
    public Sprite upgradeItem;
}
[System.Serializable]
public class DestroyItem
{
    public Sprite destroyItem;
}