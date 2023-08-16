using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void whenButtonClicked(){
        if (ProfileUI.activeInHierachy == true)
            ProfileUI.SetActive(false);
        else
            ProfileUI.SetActive(true);
    }
}
