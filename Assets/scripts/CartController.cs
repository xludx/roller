using UnityEngine;
using System.Collections;

public class CartController : MonoBehaviour {
	
	
	public WheelCollider wheelFrontRight;
	public WheelCollider wheelFrontLeft;
	public WheelCollider wheelRearRight;
	public WheelCollider wheelRearLeft;
	
	
	// configurable in editor
	private float speed = 10;
	public float breaking = 20;
	//public float turning;
	
	public GUIText speedText;
	public GUIText torqueText;
	public GUIText brakeText;
	
	
	// Use this for initialization
	void Start () {
		//SetCountText();
		//winText.text = "";
	}
	
	// Update is called once per frame before rendering the frame
	// game code
	//void Update () {
	//}
	
	// FixedUpdate is called once per frame
	// called before performing any physics calculations
	void FixedUpdate () {
		//float moveHorizontal = Input.GetAxis( "Horizontal" );
		float moveVertical = Input.GetAxis( "Vertical" );
		float speedX = moveVertical * speed;
		
		if( moveVertical >= 0 ){
			wheelRearLeft.motorTorque = speedX;
			wheelRearRight.motorTorque = speedX;
			wheelFrontLeft.brakeTorque = 0;
			wheelFrontRight.brakeTorque = 0;
		}else{		
			//wheelRearLeft.motorTorque = 0;
			//wheelRearRight.motorTorque = 0;
			wheelFrontLeft.brakeTorque = breaking;
			wheelFrontRight.brakeTorque = breaking;
		}
		
		speedText.text = "speed: " + "?";
		torqueText.text = "torque: " + wheelRearLeft.motorTorque.ToString();
		brakeText.text = "brake: " + wheelFrontRight.brakeTorque.ToString();
		
		// deltaTime = make input smooth and framerate independent
		//rigidbody.AddForce( movement * speed * Time.deltaTime );
	}

	void OnTriggerEnter( Collider other ) {
		//if( other.gameObject.tag == "Pickup" ){
		//	other.gameObject.SetActive( false );
			//count++;
			//SetCountText();
		//}
	}
	
	void SetCountText(){
		//countText.text = count.ToString();
		//if( count == 11 ){
		//	winText.text = "WINNING!";
		//}
	}
}
