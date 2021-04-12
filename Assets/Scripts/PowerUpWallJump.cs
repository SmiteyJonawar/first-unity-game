using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpWallJump : MonoBehaviour
{
    private Player player;
    

    void OnTriggerEnter() {
        player.addPowerUp("WallJump");
        
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
