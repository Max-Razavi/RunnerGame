using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
	
	bool jump = false;
	bool down = false;
	bool grounded = false;
	

    // Update is called once per frame
    void Update()
    {
        
		if (Input.GetKeyDown (KeyCode.Space)){
			jump = true;
			
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			down = true;		
		}
		
		if (this.transform.position.y <= -30){
			
			Application.LoadLevel (0);
		}
    }
	
	void FixedUpdate () {
		
		//set the velosity of character
		this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (5f, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
		
		if (jump && grounded) {
			this.GetComponent<Animator>().speed = 0;
			this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(300,650f));
			jump = false;
			grounded= false;
		}
		if (down) {
			this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-650));
		}
	}
	void OnCollisionEnter2D(){
		grounded =true;
		this.GetComponent<Animator>().speed = 1;
	}
	
	void OnTriggerEnter2D(Collider2D other){
		Destroy (other.gameObject);
		this.GetComponent<AudioSource>().Play();
		
		this.score++;
		this.UpdateScore();
		
	}
	int score = 0;
	public void UpdateScore(){
		GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().text = "Score: "+ this.score; 
	}
	
}
