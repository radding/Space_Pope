using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject target;
	public float sensitivity = 10.0f;
	public float scrollSensitivity = 100.0f;
	private float min_dist;
	// Use this for initialization
	void Start () {
		min_dist = Vector3.Distance (transform.position, target.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target.transform);
		if(Input.GetMouseButton(1)){
			transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		if (Input.GetKey (KeyCode.A)) {
			target.transform.position += Vector3.left * sensitivity * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.D)) {
			target.transform.position -= Vector3.left * sensitivity * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.W)) {
			target.transform.position += Vector3.forward * sensitivity * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.S)) {
			target.transform.position -= Vector3.forward * sensitivity * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.Q)) {
			target.transform.Rotate(Vector3.up * sensitivity * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.E)) {
			target.transform.Rotate(-Vector3.up * sensitivity * Time.deltaTime);
		}
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			if (Vector3.Distance (transform.position, target.transform.position) > min_dist) {
				transform.Translate (Vector3.forward * scrollSensitivity * Time.deltaTime * Input.GetAxis ("Mouse ScrollWheel"));
			}
		}
		else 
			transform.Translate (Vector3.forward * scrollSensitivity * Time.deltaTime * Input.GetAxis ("Mouse ScrollWheel"));
	}
}
