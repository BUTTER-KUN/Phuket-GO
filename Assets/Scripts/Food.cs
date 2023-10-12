using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food
{
    public string name;
    public string spriteID;
    public int baseCost;
    public int spokeWeight;

    public Food(string a, string b, int c, int d) {
        name = a;
        spriteID = b;
        baseCost = c;
        spokeWeight = d;
    }
}
