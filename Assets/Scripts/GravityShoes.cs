using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityShoes : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidBody;
    [SerializeField] private Transform playerTransform;
    void Start() {
        // gameObject.SetActive(false);
    }

    void Update(){
        if (Input.GetButtonDown("Fire2")){
            rotatePlayer();
        } else if(Input.GetButtonUp("Fire2")){

        }
    }

    private void rotatePlayer(){
        Vector3 cam = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15f));
        Vector2 direction = new Vector2(cam.x - playerTransform.localPosition.x, cam.y - playerTransform.localPosition.y);
        direction = direction.normalized;
        Vector3 direction3D = new Vector3(direction.x, direction.y, 0);
    }

}