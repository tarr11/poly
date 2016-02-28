using UnityEngine;

public class PolyMakerCamera : MonoBehaviour {

	public float cameraMoveSpeed = 10;
	public float speedH = 10.0f;
	public float speedV = 10.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;

	void Update () {
		yaw += speedH * Input.GetAxis("Mouse X");
		pitch -= speedV * Input.GetAxis("Mouse Y");

		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

		if (Input.GetKey(KeyCode.W)) {
			transform.Translate(Vector3.forward * Time.deltaTime * cameraMoveSpeed);
		}
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.back * Time.deltaTime * cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * Time.deltaTime * cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * Time.deltaTime * cameraMoveSpeed);
        }
    }
}
