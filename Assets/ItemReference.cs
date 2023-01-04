using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemReference : MonoBehaviour
{
    public Image itemImage;
    public Image nextFixImage;
    public Button fixButton;

    public int currentUpgradeLevel = 0;
    public int currentDestroyLevel = 4;
}
