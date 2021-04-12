using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
[SerializeField] private Transform groundCheckTransform;
[SerializeField] private LayerMask playerMask;
private Dictionary<string, bool> powerUps;
private bool jumpKeyPressed;
private float horizontalInput;
private Rigidbody rigidbodyComponent;
private float jumpCooldown;
private float nextJump;
private bool controllableMode;
private bool canControll;
private float controlTimeCooldown;
private float nextControl;
private bool wallSliding;
private bool airborne;
private float gravity;
private Quaternion smth;

    // Start is called before the first frame update
    void Start(){
        rigidbodyComponent = GetComponent<Rigidbody>();
        powerUps = new Dictionary<string, bool>();
        powerUps.Add("WallJump", false);
        powerUps.Add("Hook", false);
        powerUps.Add("GravityShoes", false);
        jumpCooldown = 0.35f;
        nextJump = Time.time + jumpCooldown;
        controllableMode = true;
        controlTimeCooldown = 0.3f;
        nextControl = Time.time + controlTimeCooldown;
        canControll = true;
        wallSliding = false;
        airborne = false;
        gravity  = 9.81f;
        smth = Quaternion.Euler(transform.eulerAngles);
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetButton("Jump")){
            jumpKeyPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate(){
        smth = Quaternion.Euler(transform.eulerAngles);
        rigidbodyComponent.AddForce(smth * new Vector3(0, -gravity, 0), ForceMode.Acceleration);
        if(!canControll){
            return;
        }

        if(!controllableMode){
            if(Time.time > nextControl){
                controllableMode = true;
            } else {
                return;
            }
        }
        
        rigidbodyComponent.velocity = new Vector3(horizontalInput * 3, rigidbodyComponent.velocity.y, 0);
        
        checkAirborne(smth);
        checkWallSliding(smth);

        if(jumpKeyPressed && Time.time > nextJump){
            nextJump = Time.time + jumpCooldown;

            if(!airborne){
                rigidbodyComponent.AddForce(smth * Vector3.up * 5, ForceMode.VelocityChange);
            } else if(powerUps["WallJump"] && wallSliding){
                if(Physics.Raycast(transform.position, smth * Vector3.right, 0.25f)){
                    Vector3 wallDirection = smth * new Vector3(-5, 5, 0);
                    rigidbodyComponent.AddForce(wallDirection, ForceMode.VelocityChange);
                    controllableMode = false;
                    nextControl = Time.time + controlTimeCooldown;
                }else if(Physics.Raycast(transform.position, smth * Vector3.left, 0.25f)){
                    Vector3 wallDirection = smth * new Vector3(5, 5, 0);
                    rigidbodyComponent.AddForce(wallDirection, ForceMode.VelocityChange);
                    controllableMode = false;
                    nextControl = Time.time + controlTimeCooldown;
                }
                
            }
            
            
        }
        jumpKeyPressed = false;
        airborne = true;
        wallSliding = false;
        
    }

    private void checkAirborne(Quaternion smth){
        if(Physics.Raycast(transform.position, smth * Vector3.down, 0.5f, playerMask)){
            airborne = false;
        }
    }

    private void checkWallSliding(Quaternion smth){
        if(Physics.Raycast(transform.position, smth * Vector3.right, 0.25f) || Physics.Raycast(transform.position, smth * Vector3.left, 0.25f)){
            wallSliding = true;
        }
    }

    public void addPowerUp(string powerUp){
        powerUps[powerUp] = true;
    }

    public void setCanControll(bool controllable){
        canControll = controllable;
    }

}
