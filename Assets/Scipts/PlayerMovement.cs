using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float gravity = 9.8f;
	public float speed = 8f;
	public float jumpForce = 5f;

	private CharacterController controller;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		controller = GetComponent <CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.isGrounded) {
			if (Input.GetKey(KeyCode.Space)) {
				velocity.y = jumpForce;
			}
		}
		velocity.y -= gravity * Time.deltaTime;
		velocity.x = Input.GetAxis ("Horizontal") * speed;
		velocity.z = Input.GetAxis ("Vertical") * speed;
		controller.Move (velocity * Time.deltaTime);
	}
}
