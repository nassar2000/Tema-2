using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Pixul : VRTK_InteractableObject
{

	
	public Tabla tabla;
	private RaycastHit touch;
	private Quaternion lastAngle;
	private bool lastTouch;

	// Use this for initialization
	void Start()
	{
		
		this.tabla = GameObject.Find("Tabla").GetComponent<Tabla>();
	}

	
	void Update()
	{
		float tipHeight = transform.Find("Tip").transform.localScale.y;
		Vector3 tip = transform.Find("Tip/TouchPoint").transform.position;

		Debug.Log(tip);

		if (lastTouch)
		{
			tipHeight *= 1.1f;
		}

		
		if (Physics.Raycast(tip, transform.up, out touch, tipHeight))
		{
			if (!(touch.collider.tag == "Tabla")) return;
			this.tabla = touch.collider.GetComponent<Tabla>();



			// Setez parametri la tabla
			tabla.SetColor(Color.blue);
			tabla.SetTouchPosition(touch.textureCoord.x, touch.textureCoord.y);
			tabla.ToggleTouch(true);

			// daca scriem, primem rasp
			if (lastTouch == false)
			{
				lastTouch = true;
				lastAngle = transform.rotation;
			}
		}
		else
		{
			tabla.ToggleTouch(false);
			lastTouch = false;
		}

		
		if (lastTouch)
		{
			transform.rotation = lastAngle;
		}
	}


}
