using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tap : MonoBehaviour
{
    public Text hitCount;
    private int hit = 100;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void count()
    {
        hit--;
        hitCount.text = "Health: " + hit;
    }
}

