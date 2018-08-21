using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    float HSpeed;
    float VSpeed;
    public float speed = 10f;
    public float JumpVelocity = 10f;
    bool isJumping = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
	}

    void GetInput()
    {
        #region Moving
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            HSpeed = Input.GetAxisRaw("Horizontal") * speed;
        }
        else
            HSpeed = 0;
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            VSpeed = Input.GetAxisRaw("Vertical") * speed;
        }
        else
            VSpeed = 0;

        #endregion


        #region Jumping
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        #endregion
    }

    private void FixedUpdate()
    {
        #region Player Movement

        Vector3 movement = new Vector3(-VSpeed, GetComponent<Rigidbody>().velocity.y, HSpeed);

        GetComponent<Rigidbody>().velocity = movement;
        #endregion

        #region Handling Jumping
        if (isJumping)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * JumpVelocity,ForceMode.Impulse);
            isJumping = false;
        }
        #endregion

    }
}
