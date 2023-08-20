using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePfpButton : MonoBehaviour
{
    public GameObject ProfileButton;
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void whenButtonClicked(){
        if (ProfileButton.activeInHierarchy == true)
            ProfileButton.SetActive(false);
        else
            ProfileButton.SetActive(true);
    }
}
