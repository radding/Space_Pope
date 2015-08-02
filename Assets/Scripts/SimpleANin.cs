using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SimpleANin : MonoBehaviour {

	public Transform start_pos;
	enum State {START, MOVE, END};
	State state = State.START;
	float time = 2.0f;
	public float speed = 2.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
			case State.START:
				break;
			case State.MOVE:
				move_up();
				break;
			case State.END:
				gameObject.GetComponent<Text>().enabled = false;
				transform.position = start_pos.position;
				state = State.START;
				break;
		}
	}

	void move_up(){
		time -= Time.deltaTime;
		if (time > 0.0f) {
			transform.Translate (Vector3.up * speed * Time.deltaTime);
		}
		else {
			state = State.END;
			time = 2.0f;
		}
	}

	public void start(){
		state = State.MOVE;
		gameObject.GetComponent<Text> ().enabled = true;
	}
}
