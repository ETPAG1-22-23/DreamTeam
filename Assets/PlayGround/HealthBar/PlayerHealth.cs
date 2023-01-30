using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Health healthBarRef;

    private int maxHealth = 100;
    private int currentHealth;




    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        healthBarRef.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(25);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBarRef.SetHealth(currentHealth);
    }
}
