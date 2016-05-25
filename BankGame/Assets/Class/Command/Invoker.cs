using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Invoker {

	private List<Move> k;

	public Invoker(){
		k = new List<Move> ();
	}
	public void doIt(Move k) 
	{ 
		this.k.Add (k);
		k.Move ();
	}
}
