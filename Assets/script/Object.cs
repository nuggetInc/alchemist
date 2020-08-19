using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object
{
	public Sprite sprite;
	public string name;

	public Object(Sprite objectSprite, string objectName)
	{
		sprite = objectSprite;
		name = objectName;
	}
}