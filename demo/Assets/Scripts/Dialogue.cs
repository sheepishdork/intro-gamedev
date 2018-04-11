using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

	public string name;

	[TextArea(3,10)]
	public string[] sentences;
}

[System.Serializable]
public class Description {

	public string itemName;

	[TextArea(3,10)]
	public string[] descriptions;
}
