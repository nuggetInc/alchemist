using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapPlacement : MonoBehaviour
{
	public int objectCount;
	public Sprite[] objectSprites;
	public string[] objectNames;

	int selectedObject = 0;

	Object[] objects;

	public HexMapHandler mapHandler;

	// Awake is called before Start
	void Awake()
	{
		objects = new Object[objectCount];

		for(int i = 0; i < objectCount; i++)
		{
			objects[i] = new Object(objectSprites[i], objectNames[i]);
		}
	}

	// Update is called once per frame
	void Update()
	{
		if(EventSystem.current.currentSelectedGameObject == null &&
		EventSystem.current.IsPointerOverGameObject() == false)
		{
			if(Input.GetMouseButtonDown(0))
			{
				Hex hex = mapHandler.layout.PixelToHex((Camera.main.ScreenToWorldPoint(Input.mousePosition))).HexRound();
				mapHandler.PlaceObject(hex, objects[selectedObject]);
			}
			else if(Input.GetMouseButtonDown(1))
			{
				Hex hex = mapHandler.layout.PixelToHex((Camera.main.ScreenToWorldPoint(Input.mousePosition))).HexRound();
				mapHandler.RemoveObject(hex);
			}
		}
	}

	public void SetSelectedDevice(int ID)
	{
		selectedObject = ID;
	}
}
