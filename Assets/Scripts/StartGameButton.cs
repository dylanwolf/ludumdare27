using UnityEngine;
using System.Collections;

public class StartGameButton : MonoBehaviour
{
    public AudioSource Sfx;
    public int Level;
    private bool clicked = false;

    void Update()
    {
        if (clicked && !Sfx.isPlaying)
        {
            Application.LoadLevel(Level);
        }
    }

	void OnMouseUpAsButton()
	{
        Sfx.Play();
	    clicked = true;
	}
}
