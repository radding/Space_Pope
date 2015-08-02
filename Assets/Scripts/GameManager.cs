using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	public GameObject build_menu;
	public GameObject build_or_move;
	public MissionUnit last_builder;
	public GameObject worshiper_count_label;
	public int worshiper_adder = 10;
	public GameObject worshiper_adder_label;
	public GameObject worshiper_subtracter;
	public float time = 30.0f;
	private int church_count = 1;
	private int worship_count = 100;
	public bool should_show_build_move;
	public HexPosition last_position = null;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		update_worship_count ();
	}

	public void display_build_or_move(MissionUnit builder){
		build_or_move.GetComponents<CanvasGroup> ()[0].alpha = 1;
		last_builder = builder;
	}

	void update_worship_count(){
		time -= Time.deltaTime;
		if (time <= 0.0f) {
			int adder = worshiper_adder * church_count;
			worship_count += adder;
			worshiper_adder_label.GetComponent<Text>().text = "+" + adder.ToString();
			worshiper_adder_label.GetComponent<SimpleANin>().start ();
			time = 30.0f;
			worshiper_count_label.GetComponent<Text>().text = worship_count.ToString();
		}
	}

	public void selected_init_build(int selected){
		// selected == 1 = build; select == 0 = move;
		switch (selected) {
		case(0):
			Debug.Log ("Selected Move");
			this.last_builder.set_state(Unit.State.MOVE);
			last_builder = null;
			break;
		case(1):
			Debug.Log ("Selected Build");
			this.last_builder.set_state(Unit.State.BUILD);
			break;
		}
		build_or_move.GetComponents<CanvasGroup> () [0].alpha = 0;
	}

	public void build_selecter(int position){
		if (this.last_builder == null)
			return;
		this.build_menu.GetComponent<CanvasGroup> ().alpha = 0;
		this.build_menu.SetActive (false);
		this.last_builder.build_on (position, this.last_position);
		this.last_position = null;
		this.last_builder = null;
	}

	public void build_place_here(HexPosition position_for_obj){
		if (last_builder == null) {
			Debug.LogError ("last_builder is null. Cant do call back");
			return;
		}
		if (last_builder.position.dist(position_for_obj) > 1){
			return;
		}
		this.build_menu.SetActive (true);
		this.build_menu.GetComponent<CanvasGroup> ().alpha = 1;
		if (this.last_position == null)
			this.last_position = position_for_obj;
	}
}
