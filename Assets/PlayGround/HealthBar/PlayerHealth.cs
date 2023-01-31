using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Health healthBarRef;
    Rigidbody2D rb;
    Animator animController;

    private int maxHealth = 100;
    private int currentHealth;
    



    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animController= GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBarRef.SetMaxHealth(maxHealth);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(25);
        }

        if (currentHealth == 0)
        {
            Death();
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBarRef.SetHealth(currentHealth);
    }

    private void Death()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        animController.SetBool("isDead", true);       
    }
}
