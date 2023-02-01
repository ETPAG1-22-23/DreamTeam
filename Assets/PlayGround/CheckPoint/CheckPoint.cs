using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Player playerRef;
    Rigidbody2D rb;
    PlayerHealth healthRef;
    private Vector3 posCheckPoint;


    public static Vector2 lastCheckPointPos;


    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
    
  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Debug.Log(playerRef.PosRespawn);
            playerRef.PosRespawn = gameObject.transform.position;
            Debug.Log(playerRef.PosRespawn);
        }

    
    }
}
