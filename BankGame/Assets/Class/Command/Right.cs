using UnityEngine;
using System.Collections;

public class Right : MonoBehaviour, Move {

	protected Burglar burglar;
	public string Parametar { get; set; }

	public Right(ref Burglar s)
	{
		burglar = s;
	}

	public void Move ()
	{
		burglar.moveRight ();
	}
}
