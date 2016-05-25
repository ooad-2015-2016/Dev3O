using UnityEngine;
using System.Collections;

public class Left : MonoBehaviour, Move {

	protected Burglar boy;
	public string Parametar { get; set; }
	
	public Left(ref Burglar s)
	{
		boy = s;
	}
	
	public void Move ()
	{
		boy.moveLeft ();
	}
}
