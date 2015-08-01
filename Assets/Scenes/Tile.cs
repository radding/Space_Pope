using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public enum Direction {
		NORTH,
		SOUTH,
		EAST,
		WEST,
		NORTH_EAST,
		NORTH_WEST,
		SOUTH_WEST,
		SOUTH_EAST
	};

	public Tile n;
	public Tile ne;
	public Tile nw;
	public Tile w;
	public Tile sw;
	public Tile se;
	public Tile e;
	public BattleUnit occupier;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void move_ocuppier(Direction dir){

	}

	public void add_tile(Tile tile, string direction){
		if (direction == "n") {
			this.n = tile;
		} else if (direction == "ne") {
			this.ne = tile;
		} else if (direction == "nw")
			this.nw = tile;
		else if (direction == "w")
			this.w = tile;
		else if (direction == "sw")
			this.sw = tile;
		else if (direction == "se")
			this.se = tile;
		else if (direction == "e")
			this.e = tile;
	}
}
