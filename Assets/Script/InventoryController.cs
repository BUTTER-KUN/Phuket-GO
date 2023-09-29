using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject joystick;
    public GameObject inventoryButton;
    public UIInventoryPage inventoryUI;

    [SerializeField]
    private InventorySO inventoryData;

    private void Start()
    {
        PrepareUI();
        //inventoryData.Initialize();
    }

    private void PrepareUI()
    {
       inventoryUI.InitializeInventoryUI(inventoryData.Size);
       this.inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
       this.inventoryUI.OnSwapItems += HandleSwapItems;
       this.inventoryUI.OnStartDragging += HandleDragging;
       this.inventoryUI.OnItemActionRequested += HandleItemActionRequest; 
    }

    private void HandleDescriptionRequest(int itemIndex)
    {
        
    }
    private void HandleSwapItems(int arg1, int arg2)
    {
        
    }
    private void HandleDragging(int itemIndex)
    {
        
    }
    private void HandleItemActionRequest(int itemIndex)
    {
        
    }

    public void ToggleInventory()
    {
        joystick.SetActive(false);
        inventoryUI.Show();
        foreach (var item in inventoryData.GetCurrentInventoryState())
        {
           inventoryUI.UpdateData(item.Key,
                item.Value.item.ItemImage,
                item.Value.quantity); 
        }
    }
}