using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Material> Materials = new List<Material>();

    private void Awake()
    {
        Instance = this;
    }

    // This method will add a MaterialItem to the Materials list.
    public void AddMaterialItem(MaterialItem materialItem)
    {
        Material material = new Material();
        material.materialItem = materialItem;
        Materials.Add(material);
    }

    public void Remove(Material material)
    {
        Materials.Remove(material);
    }
}