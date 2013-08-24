using UnityEngine;
using System.Collections;

public class StartGameButton : MonoBehaviour
{
    public AudioSource Sfx;

	void OnMouseUpAsButton()
	{
        Sfx.Play();
	    Application.LoadLevel(1);
	}
}
