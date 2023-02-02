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
        // inverser la gravit�.
        if(Input.GetKeyDown(KeyCode.E))
        { 
            rb.gravityScale *= -1;
            Rotation();
        }
    }


     // mettre le player � l'endroit : c�d pas la t�te coll�e au plafond mais � l'envers lorsque la 
    //gravit� est invers�e.
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

// � rajouter/modifier : 
// - Le saut � inverser, modifier les controles du player pour modifier son saut lorsque la gravit� est invers�e.
// - L'animation du personnage � flip lorsque la gravit� est invers�e (qu'il regarde dans le sens de la marche).
