using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Basic : MonoBehaviour {

	public GameObject Redcube; 
	public GameObject Yellowcube; 
	public GameObject Bluecube; 
	public GameObject Greencube; 
	public GameObject Magenta; 
	public FPSController controller;
	public GameObject BorderCube;
	public Text pointtext;
	public Text lifetext;

	public static int points;
	public static int lifes;
	public Vector3 magpos;
	public static int numberofcubes;


	public void Start(){
		int color;
		int x;
		int z;
		int y;
		numberofcubes = 0;
		points = 50;
		lifes = 3;



		SetPointText ();
		SetLifeText ();
		for (x = 0; x < (menuscript.number)-1; x++) {
			for (z = 0; z < (menuscript.number)-1; z++) {
				color = Random.Range (0, 4);
				if (x == (menuscript.number) / 2 && z == (menuscript.number) / 2) {
					Instantiate (Magenta, new Vector3 ((menuscript.number) / 2, 1, (menuscript.number) / 2), Quaternion.identity);

				} else {
					if (color == 0) {
						Instantiate (Bluecube, new Vector3 (x, 1, z), Quaternion.identity);
					}
					if (color == 1) {
						Instantiate (Yellowcube, new Vector3 (x, 1, z), Quaternion.identity);
					}
					if (color == 2) {
						Instantiate (Redcube, new Vector3 (x, 1, z), Quaternion.identity);
					}
					if (color == 3) {
						Instantiate (Greencube, new Vector3 (x, 1, z), Quaternion.identity);
					}
				}
			}
		}


		for (y = 0; y < 5; y++) {
			for (z = 0; z < (menuscript.number)-1; z++) {
				Instantiate (BorderCube, new Vector3 (-1, y, z), Quaternion.identity);
			}
		}
		for (y = 0; y < 5; y++) {
			for (z = 0; z < (menuscript.number)-1; z++) {
				Instantiate (BorderCube, new Vector3 ((menuscript.number)-1, y, z), Quaternion.identity);
			}
		}
		for (y = 0; y < 5; y++) {
			for (x = 0; x < (menuscript.number)-1; x++) {
				Instantiate (BorderCube, new Vector3 (x, y, -1), Quaternion.identity);
			}
		}
		for (y = 0; y < 5; y++) {
			for (x = 0; x < (menuscript.number)-1; x++) {
				Instantiate (BorderCube, new Vector3 (x, y, (menuscript.number)-1), Quaternion.identity);
			}
		}


	}

	public void Update(){
		PutCube ();
		if (lifes == 0) {
			SceneManager.LoadScene (0);
		}
		SetPointText ();
		SetLifeText ();
		Debug.Log ("points" + points);

	}
	public void PutCube(){

		int color;
		if (Input.GetMouseButtonDown (1)) {
			if (numberofcubes > 0) {
				points=points + 5;
				numberofcubes--;
				color = Random.Range (0, 4);
				if (color == 0) {
					Instantiate (Bluecube,FPSController.spawnpos, Quaternion.identity);
					Bluecube.GetComponent<Renderer> ().material.color = Color.blue;
				}
				if (color == 1) {
					Instantiate (Yellowcube,FPSController.spawnpos,Quaternion.identity);
					Yellowcube.GetComponent<Renderer> ().material.color = Color.yellow;
				}
				if (color == 2) {
					Instantiate (Redcube,FPSController.spawnpos,Quaternion.identity);
					Redcube.GetComponent<Renderer> ().material.color = Color.red;
				}
				if (color == 3) {
					Instantiate (Greencube,FPSController.spawnpos,Quaternion.identity);
					Greencube.GetComponent<Renderer> ().material.color = Color.green;
				}

			}
		}
	}

	void SetPointText(){
		pointtext.text = "Points= " + points.ToString ();
	}
	void SetLifeText(){
		lifetext.text = "Lifes= " + lifes.ToString ();
	}
}
