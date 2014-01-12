using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	
	public GameObject target;
	public float damping = 1;
	Vector3 offset;
	
	public void Start() {
		offset = target.transform.position - transform.position;
	}
	
	public void LateUpdate() {
		float currentAngle = transform.eulerAngles.y;
		float desiredAngle = target.transform.eulerAngles.y;
		float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
		
		Quaternion rotation = Quaternion.Euler(0, angle, 0);
		transform.position = target.transform.position - (rotation * offset);
		
		transform.LookAt(target.transform);
	}
	
}
//using UnityEngine;
//using System.Collections;
//
//public class FollowPlayer : MonoBehaviour {
//	
//	public GameObject target;
//	public float damping = 1;
//	public float forward = 1;
//	public Vector3 offset;
//	
//	
//	public void Start() {
//		offset = target.transform.position - transform.position;
//	}
//	
//	public void LateUpdate() {
//		float currentAngle = transform.eulerAngles.y;
//		float desiredAngle = target.transform.eulerAngles.y;
//		float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
//		
//		Quaternion rotation = Quaternion.Euler(0, angle, 0);
//		transform.position = target.transform.position - (rotation * offset);
//		Vector3 lookAt = target.transform.position;
//		lookAt += target.transform.rotation * Vector3.forward * forward;
//		lookAt.y = target.transform.position.y;
//		transform.LookAt(lookAt);
//	}
//	
//}
