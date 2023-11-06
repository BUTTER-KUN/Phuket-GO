using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Material> Materials = new List<Material>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    // This method will add a MaterialItem to the Materials list.
    public void AddMaterialItem(MaterialItem materialItem)
    {
    foreach (var material in Materials)
    {
        if (material.materialItem == materialItem)
        {
            if (material.materialItem.materialAmount < material.materialItem.maxStack)
            {
                material.materialItem.materialAmount++;

            }
            return;
        }
    }

    Material newMaterial = new Material();
    newMaterial.materialItem = materialItem;
    newMaterial.materialItem.materialAmount = 1;
    Materials.Add(newMaterial); 
    }

    public void Remove(Material material)
    {
        Materials.Remove(material);
    }

    public void ListItems()
    {
        Debug.Log("Listing Items");
        // Clear ItemContent before instantiating new items
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var material in Materials)
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent); 
                var itemIcon = obj.transform.Find("materialIcon").GetComponent<Image>();
                var itemAmount = obj.transform.Find("materialAmount").GetComponent<Text>();

                
                itemIcon.sprite = material.materialItem.materialIcon;
                itemAmount.text = "x" + material.materialItem.materialAmount.ToString();
            }
    }
}
