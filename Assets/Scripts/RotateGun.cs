using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    [SerializeField] private GrapplingGun grappling;
    [SerializeField] private Transform player;

    private Plane plane;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

         

        if(!grappling.isGrappling()){
            Vector3 cam = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15f));
            Vector2 direction = new Vector2(cam.x - player.localPosition.x, cam.y - player.localPosition.y);
            direction = direction.normalized;
            Vector3 direction3D = new Vector3(direction.x, direction.y, 0);
            transform.localPosition = direction3D;
            transform.LookAt(new Vector3(cam.x, cam.y, transform.position.z));
        } else {
            transform.LookAt(grappling.getGrapplePoint());
        }
        
        if(transform.eulerAngles.y < 1f && transform.eulerAngles.y > -1f){
            transform.localEulerAngles = new Vector3(transform.eulerAngles.x, 270f, transform.eulerAngles.z);
        }
        
    }
}
