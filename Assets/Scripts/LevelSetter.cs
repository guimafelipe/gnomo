using UnityEngine;

public class LevelSetter : MonoBehaviour {

	public Texture2D levelConfig;
	LevelMap levelMap;

	public ColorToPrefab[] colorMap;

	// Use this for initialization
	void Start () {
		//GenerateLevel ();
		levelMap = GameObject.Find ("LevelMap").GetComponent<LevelMap>();
	}

	public void GenerateLevel(){
		for (int i = 0; i < levelConfig.width; i++) {
			for (int j = 0; j < levelConfig.height; j++) {
				SpawnEnemy (i, j);
			}
		}
	}

	void SpawnEnemy(int i, int j){
		Color pixelColor = levelConfig.GetPixel(i, j);
		if(pixelColor.a == 0){
			//Pixel trasparent
			return; //ignored
		}

		foreach (ColorToPrefab element in colorMap) {
			if (element.color.Equals (pixelColor)) {
				Debug.Log (element.color);
				Debug.Log (pixelColor);
				//TODO: Mandar level map criar gnomo na lane i e no spot lane[i].size() - j - 1;
			
				levelMap.SpawnEnemy(element.prefab, i, j);
				return;
			}
		}

	}

}
