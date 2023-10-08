using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScript : MonoBehaviour
{
    [HideInInspector] // This will hide the Material field in the Unity Inspector
    public Material material;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InventoryManager.Instance.AddMaterialItem(material.materialItem); // Add MaterialItem to the list
            Destroy(gameObject);
            Debug.Log(material.materialItem.materialName);
        }
    }
}
