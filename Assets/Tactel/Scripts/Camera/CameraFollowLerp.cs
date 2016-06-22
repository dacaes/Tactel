using UnityEngine;

public class CameraFollowLerp : MonoBehaviour
{
	public Transform target;
	public float velocity;
	
	void Update () {
		transform.position = new Vector3 (Mathf.Lerp (transform.position.x, target.position.x, velocity * Time.deltaTime),
			transform.position.y,
			Mathf.Lerp (transform.position.z, target.position.z, velocity * Time.deltaTime));
	}
}
