using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = playerTransform.position;
        transform.position = new Vector3(playerPos.x,playerPos.y + 1 ,playerPos.z - 10);
    }
}
