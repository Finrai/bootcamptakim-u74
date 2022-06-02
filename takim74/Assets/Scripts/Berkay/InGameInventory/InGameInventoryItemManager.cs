using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameInventoryItemManager : MonoBehaviour
{
    public Item item;
    public Image image;
    public PlayerInGameInventoryManager inventory;
    private bool flag;
    [SerializeField] private Slider slider;

    private void Awake()
    {
        inventory = GetComponentInParent<PlayerInGameInventoryManager>();
        image = GetComponentInChildren<Image>();  
        slider = GetComponentInChildren<Slider>();
    }

    private void Update() 
    {
        slider.gameObject.SetActive(transform.GetChild(0).transform.gameObject.GetComponent<Image>().enabled);

        if(slider.gameObject.activeInHierarchy == true)
        {
            slider.maxValue = item._initialDuration;
            slider.minValue = 0;

            slider.value = GetComponentInParent<PlayerInGameInventoryManager>().durationSynchronizer
                .shopPlayerInventorys[0].transform.GetChild(this.transform.GetSiblingIndex()).GetComponent<ShopItemManager>().duration;
        }
    }
}
