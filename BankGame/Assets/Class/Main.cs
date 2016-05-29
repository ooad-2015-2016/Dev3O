using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	public Burglar burglar;
	public Invoker i = new Invoker();
	public Move Left;
	public Move Right;
	public Bag bag;
	public List<IState> istate;
	public GameObject gameOverText;
	public GameObject restartButton;
	public Observer o;
	void Start()
	{
		Left = new Left(ref burglar);
		Right = new Right(ref burglar);
		istate = new List<IState>();

		StartCoroutine (Rutina ());
	}
	
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.RightArrow)) { i.doIt(Right); }
		if (Input.GetKey(KeyCode.LeftArrow)) { i.doIt(Left); }
	}

	IEnumerator Rutina()
	{
		while (burglar.getNegative() != 0) {

			burglar.register(ref bag);

			yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));

			burglar.remove(bag);
		}
		yield return new WaitForSeconds(1.0f);
		gameOverText.SetActive (true);
		yield return new WaitForSeconds(2.0f);
        gameOverText.SetActive(false);
		restartButton.SetActive (true);
	}
}
