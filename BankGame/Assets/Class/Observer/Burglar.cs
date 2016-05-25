using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Burglar : MonoBehaviour, Subject {

	private List<Bag> observer = new List<Bag>();
	private int points;
	public int negativePoints;
	private Position position;
	private float maxwidth ;
	private Camera cam;
	private Rigidbody2D rgbd2;
	private Renderer rend;
	public Text scoreText;
	public Text lifeText;
	public GameObject gameOverText;
	public GameObject restartButton;

	void Start()
	{
		observer = new List<Bag> ();
		position = new Position ();
		rend = GetComponent<Renderer>();
		points = 0;
		negativePoints = 3;
		if(cam==null) cam=Camera.main;
		rgbd2= this.gameObject.GetComponent<Rigidbody2D>();
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float playerWidth = rend.bounds.extents.x;
		maxwidth = targetWidth.x-playerWidth;
	}
	
	public void register(ref Bag o)
	{
		observer.Add (o);
		o.Kreni ();
	}

	public void remove(Bag o)
	{
		if (observer.Count > 2) {
			observer.Remove (o);
		}
	}

	public void notify()
	{
		if (observer != null) {
			observer.ForEach (x => x.update (this.position));
		}
	}

	public void move(float x)
	{
		Vector3 position = new Vector3(x, 0, 0); 
		this.transform.position = position;
		notify ();
	}
	public void moveLeft()
	{
		position.x -= 0.33f; 
		if (position.x < -maxwidth) position.x = -maxwidth;
		move (position.x);
	}

	public void moveRight()
	{
		position.x += 0.33f; 
		if (position.x > maxwidth) position.x = maxwidth;
		move (position.x);
	}

	public Position getPosition()
	{
		return this.position;
	}

	public int getPoints()
	{
		return points;
	}

	public int getNegative()
	{
		return negativePoints;
	}

	public void setPoints(int bodovi)
	{
		this.points += bodovi;
	}

	public void setNegative(int neg)
	{
		this.negativePoints += neg;
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "C" && getNegative() != 0) {
			setNegative(-1);
			Destroy (other.gameObject);

		} else if (other.gameObject.tag == "P" && getNegative() != 0) {

			setPoints(10);
			Destroy (other.gameObject);
			
		} else if (other.gameObject.tag == "Z" && getNegative() != 0) {
			setPoints (50);
			Destroy (other.gameObject);
		} 
		scoreText.text = "Bodovi:\n" + getPoints();
		lifeText.text = "Zivoti: " + getNegative ();
	}
}
