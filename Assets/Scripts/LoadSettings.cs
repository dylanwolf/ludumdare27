using UnityEngine;
using System.Collections;

public class LoadSettings : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
        SixthsGameState.Noise = PlayerPrefs.GetInt("Noise", SixthsGameState.Noise);
	    SixthsGameState.Goal = PlayerPrefs.GetInt("Goal", SixthsGameState.Goal);
	}
}
