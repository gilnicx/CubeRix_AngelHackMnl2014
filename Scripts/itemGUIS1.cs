using UnityEngine;
using System.Collections;

public class itemGUIS1 : MonoBehaviour {

	private string box1 = "If a < b, \nexchange \na and b";
	private string box2 = "Divide a by b \nand get the \nremainder, r. \n If r = 0, \nreport b as the \nGCD of a & b";
	private string box3 = "Replace a by b \n& replace b by \nr. \n Return to \nprevious step";

	void OnGUI (){

		GUI.Box (new Rect (0, 0, 100, 25), "box1");
		GUI.Box (new Rect (0, 26, 100, 100), box1);

		GUI.Box (new Rect (100, 0, 100, 25), "box2");
		GUI.Box (new Rect (100, 26, 100, 100), box2);

		GUI.Box (new Rect (200, 0, 100, 25), "box3");
		GUI.Box (new Rect (200, 26, 100, 100), box3);
		
	}
}
