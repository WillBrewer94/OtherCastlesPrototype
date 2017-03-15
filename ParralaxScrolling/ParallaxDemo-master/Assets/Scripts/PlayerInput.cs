using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {
    Player player;
    Animator anim;
    public Controller2D cursor;

    void Start() {
        player = GetComponent<Player>();
        anim = GetComponentInChildren<Animator>();
	}
	
	void Update() {
        Vector2 dirInput = new Vector2(Input.GetAxis("Horizontal"), 0);
        player.SetDirectionalInput(dirInput);
        //anim.SetFloat("Speed", Mathf.Abs(dirInput.x));

        if(Input.GetKeyDown(KeyCode.Space)) {
            player.OnJumpInputDown();
        }

        if(Input.GetKeyUp(KeyCode.Space)) {
            player.OnJumpInputUp();
        }

        
    }

    //Returns a vector direction of the right joystick
    Vector2 JoyAngle() {
        //X, Y, and angle of right joystick
        float joyX = Input.GetAxis("PS4_LeftStickX");
        float joyY = Input.GetAxis("PS4_LeftStickY");

        //Gets computes angle from origin of right joystick location
        float joyAngle = Mathf.Atan2(joyX, joyY) * 57;

        return new Vector2(joyX, joyY);
    }
}
