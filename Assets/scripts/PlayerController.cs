using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// configurable in editor
	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;
	
	// Use this for initialization
	void Start () {
		count = 0;
		SetCountText();
		winText.text = "";
	}
	
	// Update is called once per frame before rendering the frame
	// game code
	//void Update () {
	//}
	
	// FixedUpdate is called once per frame
	// called before performing any physics calculations
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis( "Horizontal" );
		float moveVertical = Input.GetAxis( "Vertical" );
		
		Vector3 movement = new Vector3( moveHorizontal, 0.0f, moveVertical );
		
		// deltaTime = make input smooth and framerate independent
		rigidbody.AddForce( movement * speed * Time.deltaTime );
	}

	void OnTriggerEnter( Collider other ) {
		if( other.gameObject.tag == "Pickup" ){
			other.gameObject.SetActive( false );
			count++;
			SetCountText();
		}
	}
	
	void SetCountText(){
		countText.text = count.ToString();
		if( count == 11 ){
			winText.text = "WINNING!";
		}
	}
}
