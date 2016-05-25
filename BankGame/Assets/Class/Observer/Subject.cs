using UnityEngine;
using System.Collections;

public interface Subject{

	void register(ref Bag o);
	void remove(Bag o);
	void notify(); 
}
