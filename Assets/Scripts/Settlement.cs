using UnityEngine;
using System.Collections;

public class Settlement : MissionUnit {
	public void start_at(HexPosition destination){
		destination.add ("Unit", this);
		this.moving = true;
		this.position = destination;
	}

	public override void _select_cb(HexGrid caller){
		this.state = State.DONE;
		grid.state_change (this);
	}

}