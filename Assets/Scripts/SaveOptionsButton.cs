using UnityEngine;
using System.Collections;

public class SaveOptionsButton : MonoBehaviour
{

    public SliderHandler NoiseSlider;
    public SliderHandler TargetsSlider;
    public AudioSource Sfx;
    private bool clicked = false;

	// Use this for initialization
	void Start ()
	{
	    NoiseSlider.SetValue(SixthsGameState.Noise);
        TargetsSlider.SetValue(SixthsGameState.Goal);
	}
	
    void Update()
    {
        if (clicked && !Sfx.isPlaying)
        {
            Application.LoadLevel(0);
        }
    }

	void OnMouseUpAsButton ()
	{
        Sfx.Play();
	    clicked = true;
	    SixthsGameState.Noise = NoiseSlider.Value;
	    SixthsGameState.Goal = TargetsSlider.Value;

        PlayerPrefs.SetInt("Noise", SixthsGameState.Noise);
        PlayerPrefs.SetInt("Goal", SixthsGameState.Goal);
        PlayerPrefs.Save();
	}
}
