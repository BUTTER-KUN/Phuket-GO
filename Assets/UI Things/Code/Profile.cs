using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    public Image profileui;
    public string inputButton = "Fire1";
    public float holdDuration = 1.0f;

    private bool isHoldingButton = false;
    private float holdStartTime = 0.0f;

    private void Start()
    {
        profileui.gameObject.SetActive(false);
    }

    public void ShowProfile()
    {
        if (Input.GetButton(inputButton))
        {
            if (!isHoldingButton)
            {
                isHoldingButton = true;
                holdStartTime = Time.time;
            }

            if (Time.time - holdStartTime >= holdDuration)
            {
                profileui.gameObject.SetActive(true);
            }
        }
        else
        {
            isHoldingButton = false;
        }
    }

    public void HideProfile()
    {
        isHoldingButton = false;
        profileui.gameObject.SetActive(false);
    }

    void Update()
    {
        ShowProfile();
    }
}
