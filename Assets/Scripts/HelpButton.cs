using UnityEngine;
using System.Collections;

public class HelpButton : MonoBehaviour
{

    public Transform HelpPanel;
    public AudioSource Sfx;
    public AudioSource Transition;
    public float TranslationZ;
	
	void OnMouseUpAsButton()
	{
        Sfx.Play();
	    HelpPanel.Translate(0, 0, TranslationZ - HelpPanel.transform.position.z);
        Transition.Play();
	}
}
