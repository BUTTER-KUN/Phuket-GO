using UnityEngine;

[CreateAssetMenu(fileName = "New Material", menuName = "Material/Create New Item")]
public class MaterialItem : ScriptableObject
{
    public int materialID;
    public string materialName;
    public string materialDescription;
    public int value;
    public int materialAmount = 1;

    public int maxStack = 20;
    public Sprite materialIcon;
    public GameObject materialPrefab; 
}
