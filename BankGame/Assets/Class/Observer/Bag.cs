using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bag : MonoBehaviour, Observer, IState {

	private IState state;
	private int points;
	private Position position;
	public Subject subject;
	private Camera cam;
	private float maxwidth;
	private Rigidbody2D rgbd2;
	public List<GameObject> bags;
	private GameObject t;

	public Bag(){}

	void FixedUpdate () {
		//Debug.Log ("X: " + this.transform.position.x);
		//Debug.Log ("Y: " + this.transform.position.y);

	}

	public void Kreni()
	{
		if (cam == null) { cam = Camera.main; }
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float poklonWidth = bags[0].GetComponent<Renderer>().bounds.extents.x;
		maxwidth = targetWidth.x - poklonWidth;	
		
		Vector3 spawnPosition = new Vector3 (Random.Range (-maxwidth, maxwidth), 8.0f, 0.0f);
		Quaternion spawnRotation = Quaternion.identity;

		int j = Random.Range (0, 3);
		t = bags [j];
		if (t.tag == "C") {
			state = new Bomb();
			points = state.updatePoints();
		}
		if (t.tag == "P") {
			state = new BigBag();
			points = state.updatePoints();
		}
		if (t.tag == "Z") {
			state = new SmallBag();
			points = state.updatePoints();
		}

		Instantiate (t, spawnPosition, spawnRotation);
	}

	public void update(Position pozicija){

	}


	public void setBrojPoena(int brojPoena)
	{
		this.points = brojPoena;
	}

	public int getBrojPoena()
	{
		return points;
	}
	
	//Odnose se na state pattern
	public void setState(IState state)
	{
		this.state = state;
		points = updatePoints ();
	}
	
	public int updatePoints()
	{
		return state.updatePoints ();
	}
	void OnTriggerEnter2D(Collider2D other)
	{

	}
}
