using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    Rigidbody2D rb;
    bool top;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // inverser la gravité.
        if(Input.GetKeyDown(KeyCode.E))
        { 
            rb.gravityScale *= -1;
            Rotation();
        }
    }


     // mettre le player à l'endroit : càd pas la tête collée au plafond mais à l'envers lorsque la 
    //gravité est inversée.
    void Rotation()
    {
        if(top == false){
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else { 
            transform.eulerAngles = Vector3.zero; 
        }
        top = !top;

    }
}

// à rajouter/modifier : 
// - Le saut à inverser, modifier les controles du player pour modifier son saut lorsque la gravité est inversée.
// - L'animation du personnage à flip lorsque la gravité est inversée (qu'il regarde dans le sens de la marche).
