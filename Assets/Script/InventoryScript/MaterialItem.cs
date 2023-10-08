using UnityEngine;

[CreateAssetMenu(fileName = "New Material", menuName = "Material/Create New Item")]
public class MaterialItem : ScriptableObject
{
    public int materialID;
    public string materialName;
    public string materialDescription;
    public int value;
    public Sprite materialIcon;
    public GameObject materialPrefab; // Add a reference to the corresponding prefab.
}
