using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInGameInventoryManager : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public Canvas canvas;
    public DurationSynchronizer durationSynchronizer;

    [SerializeField] List<AudioClip> clips = new List<AudioClip>();
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        FillParentGameObjectsWithInventoryItems();

        if(canvas != null)
        {
            canvas.enabled = false;
        }

    }

    void Update()
    {
        FillParentGameObjectsWithInventoryItems();
        FillItemImages();
        CalculateWeight();

        if(Input.GetKeyDown(KeyCode.K) && canvas != null)
        {
            if(canvas.enabled == true) 
            {
                audioSource.clip = clips[1];
                audioSource.Play();

                canvas.enabled = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else 
            {
                audioSource.clip = clips[1];
                audioSource.Play();
                
                canvas.enabled = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    void FillParentGameObjectsWithInventoryItems()
    {
         if(playerInventory.items.Count > transform.childCount)
        {
            int difference = playerInventory.items.Count - transform.childCount;

            for(int i = difference; i != 0; i--)
            {
                playerInventory.items.RemoveAt(playerInventory.items.Count -1);
            }
        }


        for(int j=playerInventory.items.Count; j<transform.childCount; j++)
        {
            transform.GetChild(j).transform.GetChild(0).gameObject.GetComponent<Image>().enabled = false;
        }

        for(int i=0; i< playerInventory.items.Count; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<InGameInventoryItemManager>().item = playerInventory.items[i];
            transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<Image>().enabled = true;
        }

    }


    public void CalculateWeight()
    {
        playerInventory.currentWeight = 0;

        foreach(Item item in playerInventory.items)
        {
            playerInventory.currentWeight += item._weight;
        }
        
    }

    public void FillItemImages()
    {
        for(int i=0; i<playerInventory.items.Count; i++)
        {
            transform.GetChild(i).GetComponent<InGameInventoryItemManager>().image.sprite = transform.GetChild(i).GetComponent<InGameInventoryItemManager>().item._sprite;
        }
    }   

    public void DeleteItem() 
    {
        
        audioSource.clip = clips[0];
        audioSource.Play();

        var selectedItemIndex = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();

        for(int i=selectedItemIndex; i<playerInventory.maxSize; i++) 
        {
           if(i != playerInventory.maxSize - 1)
           {
                durationSynchronizer.shopPlayerInventorys[0].transform.GetChild(i).GetComponent<ShopItemManager>().duration =
                durationSynchronizer.shopPlayerInventorys[0].transform.GetChild(i+1).GetComponent<ShopItemManager>().duration;
           }
           else
           {
               Debug.Log("last item");
           }
        }



        playerInventory.items.RemoveAt(selectedItemIndex);
    }
}
