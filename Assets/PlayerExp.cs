using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    private int experience;
    public int Experience
    {
        get
        {
            return experience;
        }
        set
        {
            experience = value;
        }
    }

    public int Level 
    {
        get
        {
            return Mathf.Clamp(experience / 1000, 1, 10); // Adjusted to have a level range from 1 to 10
        }
        set
        {
            experience = Mathf.Clamp(value, 1, 10) * 1000; // Adjusted to have a level range from 1 to 10
        }
    }
}