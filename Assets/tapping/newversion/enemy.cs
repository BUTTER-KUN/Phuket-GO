using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemy : MonoBehaviour
{
    public Image healthBar;
    public float health = 10f;
    public Animator swordAnimator; // Reference to the Animator component of the sword animation object

    private void Start()
    {
        // Assuming the sword animation object is a child of the enemy
        swordAnimator = GetComponentInChildren<Animator>();
    }

    void OnMouseDown()
    {
        TakeDamage();
        
        // Trigger the attack animation
        swordAnimator.SetTrigger("attack");
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage()
    {
        health--;
        healthBar.fillAmount = health / 10f;
    }
}
