using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSetup : MonoBehaviour {
	public int width, height;

	public GameObject background;

	public GameObject block;
	private GameObject[,] placeholder;

	// Use this for initialization
	void Start () {
		placeholder = new GameObject[height, width];

		for( int row = 0; row < height; row++ ) {
			for( int col = 0; col < width; col++ ) {
				// Create a block (placeholder)
				placeholder[row,col] = Instantiate(block);
				
				// Place the block at the correct position
				Vector2 bottom_left = new Vector2(
					background.transform.position.x - background.transform.localScale.x / 2f,
					background.transform.position.y - background.transform.localScale.y / 2f
				);
				Vector2 coord = new Vector2(
					(row + .5f) * background.transform.localScale.y / height,
					(col + .5f) * background.transform.localScale.x / width
				);
				placeholder[row,col].transform.position = bottom_left +  coord;

				// Scale the block so that everything fits nicely
				float background_size = Mathf.Min(background.transform.localScale.x, background.transform.localScale.y);
				int stack_size = Mathf.Min(height, width);
				Vector2 size = new Vector2(
					0.95f * background_size / stack_size,
					0.95f * background_size / stack_size
				);
				placeholder[row,col].transform.localScale = size;

				Debug.Log(placeholder[row,col]);
			}
		}
	}	
}