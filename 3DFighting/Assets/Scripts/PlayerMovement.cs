using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float rotationSpeed = 140f;
	public float speed = 20f;
	public float jumpSpeed = 10f;

	private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {



//		transform.Translate (x, 0, 0); // horizontal movement
//		transform.Translate (0, 0, z); // vertical movement
//		if(grounded) {
//			transform.Translate (0, y, 0); // jump movement
//			print ("Jumping");
//			if (Input.GetAxis ("Jump") > 0f)
//				grounded = false;
//		}
		//grounded = false;


	}

	void FixedUpdate ()
	{

		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * speed;
		var z = Input.GetAxis ("Vertical") * Time.deltaTime * speed;
		var y = Input.GetAxis ("Jump") * Time.deltaTime * jumpSpeed;

		bool m_Grounded = Physics.Raycast (transform.position,
			transform.up * -1,
			0.6f, 1 << LayerMask.NameToLayer ("Ground"));


		if (m_Grounded)
		{
//			transform.Translate (x, 0, 0); // horizontal movement
//			transform.Translate (0, 0, z); // vertical movement

			rigidbody.AddForce (x, 0, 0);
			rigidbody.AddForce (0, 0, z);

			if (Input.GetButton("Jump"))
			{
				m_Grounded = false;
				rigidbody.AddForce (0, 200, 0);
			}
		}

	}


	void OnDrawGizmos ()
	{
		Gizmos.DrawLine (transform.position,
			transform.position + transform.up * -0.6f);
	}
}
