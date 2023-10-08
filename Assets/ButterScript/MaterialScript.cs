using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScript : MonoBehaviour
{
    [HideInInspector]
    public Material material;

    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.gameObject.CompareTag("Player"))
    {
        InventoryManager.Instance.AddMaterialItem(material.materialItem);
        material.materialItem.materialAmount++;

        // Check if the amount exceeds the max stack size
        if (material.materialItem.materialAmount > material.materialItem.maxStack)
        {
            material.materialItem.materialAmount = material.materialItem.maxStack;
        }

        Destroy(gameObject);
        Debug.Log(material.materialItem.materialName);
    }
    }
}