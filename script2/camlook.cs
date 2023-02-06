using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camlook : MonoBehaviour
{
	public float minX = -60f;
	public float maxX = 60f;
	//public float lookSpeed = 2.0f;

	public float sensitivity;
	public Camera cam;

	float rotY = 0f;
	float rotX = 0f;
	private bool attackmode = false;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

    void Update()
    {
		if(Input.GetMouseButtonDown(1))
		{
			attackmode = !attackmode;
		}
		rotY += Input.GetAxis("Mouse X") * sensitivity;
		rotX += Input.GetAxis("Mouse Y") * sensitivity;

		rotX = Mathf.Clamp(rotX, minX, maxX);
		//rotY = Mathf.Clamp(rotY, minX, maxX);

		//transform.localEulerAngles = new Vector3(0, rotY, 0);
		cam.transform.localEulerAngles = new Vector3(-rotX, 0, 0);
		if(attackmode)
		{
			//transform.rotation = Quaternion.Euler(0,rotY * sensitivity, 0);
		}
        //transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);


	}

}
