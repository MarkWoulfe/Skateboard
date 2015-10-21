using UnityEngine;
using System.Collections;

public class VelocityRotate : MonoBehaviour {

	[SerializeField] private float speed;
    [SerializeField] private float angularThreshold;

	private bool buttonDown = false;
	private Rigidbody myRigidbody;
	private Vector3 lastPos = Vector3.zero;
	private Vector3 currentPos = Vector3.zero;
	private Vector3 rotationDir = Vector3.zero;

	// Use this for initialization
	void Start () {
		myRigidbody = (Rigidbody)GetComponent (typeof(Rigidbody));
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) 
		{
			lastPos = Input.mousePosition;
		}

		if (Input.GetMouseButton (0)) 
		{
			currentPos = Input.mousePosition;
			rotationDir = lastPos - currentPos;
			rotationDir = new Vector3(-rotationDir.y,rotationDir.x,rotationDir.z);
			lastPos = currentPos;
			buttonDown = true;
		}

		if (Input.GetMouseButtonUp (0)) 
		{
			buttonDown = false;
		}

	}

	void FixedUpdate()
	{
        if (buttonDown) myRigidbody.AddTorque(rotationDir * speed * Time.fixedDeltaTime, ForceMode.Impulse);
        else if (myRigidbody.angularVelocity.sqrMagnitude < angularThreshold)
        {
            myRigidbody.angularVelocity = Vector3.zero;
        }
	}

}
