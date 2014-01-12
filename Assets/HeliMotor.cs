using UnityEngine;
using System.Collections;

public class HeliMotor : MonoBehaviour {

	public void Start() {
	
	}
	
	public void Update() {
		// Input
		float thrust = Mathf.Clamp(Input.GetAxis("Vertical") + Input.GetAxis("Vertical2"), -1, 1);
		float spin = Input.GetAxis("Horizontal");
		float strafe = Input.GetAxis("Horizontal2");
		
		// Rotate left/right
		if (!Mathf.Approximately(thrust + spin, 0)) {
			transform.Rotate(Vector3.up * spin, Space.World);
		}
		
		// Tilt forward/back and left/right
		transform.rotation = Quaternion.Euler(
			Mathf.LerpAngle(transform.eulerAngles.x, thrust * 25, Time.deltaTime), 
			transform.eulerAngles.y, 
//			strafe * 25
			Mathf.LerpAngle(transform.eulerAngles.z, strafe * 25, Time.deltaTime)
		);
		
		// Constrain tilt
		Vector3 eulerAngles = transform.eulerAngles;
		if (eulerAngles.x > 25 && eulerAngles.x < 180) {
			eulerAngles.x = 25;   
		} else if (eulerAngles.x < 335 && eulerAngles.x > 180) {
			eulerAngles.x = 335;
		}
		
		if (eulerAngles.z > 25 && eulerAngles.z < 180) {
			eulerAngles.z = 25;   
		} else if (eulerAngles.z < 335 && eulerAngles.z > 180) {
			eulerAngles.z = 335;
		}
		
		transform.eulerAngles = eulerAngles;
		
		// Init move
		Vector3 position = transform.position;
		float speed;
		
		// Move forward
		if (transform.eulerAngles.x < 180) {
			speed = transform.eulerAngles.x;
		} else {
			speed = transform.eulerAngles.x - 360;
		}
		speed /= 10;
		position += transform.rotation * Vector3.forward * speed;
		
		// Strafe
		if (transform.eulerAngles.z < 180) {
			speed = transform.eulerAngles.z;
		} else {
			speed = transform.eulerAngles.z - 360;
		}
		speed /= 10;
		position += transform.rotation * Vector3.left * speed;
		
		// Constrain Y position
		position.y = transform.position.y;
		
		// Apply movement
		transform.position = position;
	}
}
