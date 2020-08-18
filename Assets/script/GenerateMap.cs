using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateMap : MonoBehaviour
{
	public int radius;

	public Tilemap grid;
	public TileBase defaultTile;

	// Start is called before the first frame update
	void Start()
	{
		for(int x = -radius; x <= radius; x++)
			for(int y = -radius; y <= radius; y++)
				if(x <= radius - Mathf.Abs(y))
					grid.SetTile(new Vector3Int(x + Mathf.Abs(y / 2), y, 0), defaultTile);
	}
}
