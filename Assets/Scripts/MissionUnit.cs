using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissionUnit : Unit {
	public List<Settlement> buildings;
	public int selected_index = 0;

	public override void _select_cb(HexGrid caller){
		caller.set_build_state ();
		this.Status = State.WAIT_FOR_ORDERS;
		gm.display_build_or_move (this);
	}

	public void set_state(Unit.State new_state){
		this.state = new_state;
		grid.state_change (this);
	}

	public void build_on(int selected, HexPosition destination){
		Debug.Log ("Selected " + selected.ToString ());
		Settlement unit = this.buildings[selected];
		GameObject unit_go = (GameObject) Instantiate (unit.gameObject, destination.getPosition(), new Quaternion());
		unit_go.transform.parent = GameObject.FindGameObjectWithTag ("Units").transform;
		grid.AddUnit (unit);
		unit.SetGrid (grid);
		grid.ai.add_unit (unit);
		this.state = State.DONE;
		grid.state_change (this);
	}

}
