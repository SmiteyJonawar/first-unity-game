using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 grapplePoint;
    private float maxDistance = 5f;
    private SpringJoint joint;
    private Player player;
    [SerializeField] private Transform gunTip, playerTransform;

    void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        gameObject.SetActive(false);
        player = GameObject.FindObjectOfType<Player>();
    }

    void Update(){
        if (Input.GetButtonDown("Fire1")){
            StartGrapple();
            player.setCanControll(false);
        } else if(Input.GetButtonUp("Fire1")){
            StopGrapple();
            player.setCanControll(true);
        }
    }

    void LateUpdate() {
        DrawRope();
    }

    void StartGrapple(){
        RaycastHit hit;
        Vector3 cam = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15f));
        Vector2 direction = new Vector2(cam.x - playerTransform.localPosition.x, cam.y - playerTransform.localPosition.y);
        direction = direction.normalized;
        Vector3 direction3D = new Vector3(direction.x, direction.y, 0);
        // Debug.DrawRay(gunTip.position, direction3D, Color.green);
        if(Physics.Raycast(gunTip.position, direction3D, out hit, maxDistance)){
            if(hit.transform.tag == "Grabbleable"){
                grapplePoint = hit.point;
                joint = playerTransform.gameObject.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = grapplePoint;

                float distanceFromPoint = Vector3.Distance(playerTransform.position, grapplePoint);

                joint.maxDistance = distanceFromPoint * 0.8f;
                joint.minDistance = distanceFromPoint * 0.2f;

                joint.spring = 100f;
                joint.damper = 7f;
                // joint.massScale = 4.5f;

                lineRenderer.positionCount = 2;
            }
        }
    }

    void DrawRope(){
        if(!joint){
            return;
        }
        lineRenderer.SetPosition(0, gunTip.position);
        lineRenderer.SetPosition(1, grapplePoint);
    }

    void StopGrapple(){
        lineRenderer.positionCount = 0;
        Destroy(joint);
    }

    public bool isGrappling(){
        return joint != null;
    }

    public Vector3 getGrapplePoint(){
        return grapplePoint;
    }
}
