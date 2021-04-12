using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHook : MonoBehaviour
{
    private Player player;
    private GrapplingGun grapplingGun;
    void OnTriggerEnter() {
        player.addPowerUp("Hook");
        grapplingGun.gameObject.SetActive(true);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        grapplingGun = GameObject.FindObjectOfType<GrapplingGun>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
