using UnityEngine;
using System.Collections;

public class PinHandler : MonoBehaviour
{
    private tk2dSprite sprite;
    public string PinUpSprite = "pin_up";
    public string PinDownSprite = "pin_down";
    private bool lastButton = false;
    private bool thisButton = false;
    private Vector3 pos = new Vector3(0, 0, 0);
	
	void Start ()
	{
	    sprite = GetComponent<tk2dSprite>();
	}
	
	
	void Update ()
	{
	    pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	    pos.z = transform.position.z;
	    transform.position = pos;

	    thisButton = Input.GetMouseButton(0);
        if (thisButton != lastButton)
        {
            sprite.SetSprite(thisButton ? PinDownSprite : PinUpSprite);
        }
	    lastButton = thisButton;
	}
}
