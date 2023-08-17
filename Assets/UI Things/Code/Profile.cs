using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile : MonoBehaviour
{
    public GameObject ProfileUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void whenButtonClicked(){
        if (ProfileUI.activeInHierarchy == true)
            ProfileUI.SetActive(false);
        else
            ProfileUI.SetActive(true);
    }
}
