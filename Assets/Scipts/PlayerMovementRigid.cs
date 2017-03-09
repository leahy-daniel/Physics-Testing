using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRigid : MonoBehaviour {

	public float speed = 8f;
	public float jumpForce = 90f;

	Vector3 velocity;
	float distanceToGround;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		velocity = Vector3.zero;
		rb = GetComponent<Rigidbody> ();
		distanceToGround = GetComponent<CapsuleCollider> ().bounds.extents.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isGrounded()) {
			if (Input.GetKey(KeyCode.Space)) {
				rb.AddForce (0f, jumpForce, 0f);
			}
		}
		velocity.x = Input.GetAxis ("Horizontal") * speed;
		velocity.z = Input.GetAxis ("Vertical") * speed;
		rb.MovePosition (transform.position + velocity * Time.deltaTime);
	}

	bool isGrounded() {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.up, out hit)) {
			return hit.distance <= distanceToGround + 0.1;
		} else {
			return false;
		}
	}
}
