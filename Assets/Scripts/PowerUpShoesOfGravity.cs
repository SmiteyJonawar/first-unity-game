using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShoesOfGravity : MonoBehaviour
{
    private Player player;
    private GravityShoes gravityShoes;

    void OnTriggerEnter() {
        player.addPowerUp("GravityShoes");
        gravityShoes.gameObject.SetActive(true);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        gravityShoes = GameObject.FindObjectOfType<GravityShoes>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
