using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeadZone : MonoBehaviour
{

    void OnTriggerEnter() {
         SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
