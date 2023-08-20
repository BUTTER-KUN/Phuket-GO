using UnityEngine;

public class RadialMenuHideShow : MonoBehaviour
{
    public Transform buttonGroup;
    public float bottomHalfAngle = 180.0f; // Angle to define the bottom half

    // Reference to the buttons (you'll need to assign these in the Inspector)
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    private void Update()
    {
        float currentAngle = buttonGroup.eulerAngles.z;
        
        // Calculate the angle for the button that is in the bottom half
        float buttonAngle = currentAngle - bottomHalfAngle;

        // Check if the button is in the bottom half
        if (buttonAngle > 0 && buttonAngle <= 180)
        {
            HideButtonInBottomHalf();
        }
        else
        {
            ShowButtonInBottomHalf();
        }
    }

    private void HideButtonInBottomHalf()
    {
        // Hide the buttons in the bottom half
        button3.SetActive(false);
        button4.SetActive(false);
    }

    private void ShowButtonInBottomHalf()
    {
        // Show the buttons in the bottom half
        button3.SetActive(true);
        button4.SetActive(true);
    }
}
