using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ABFileLoad : MonoBehaviour {

	public Transform backgroundTF;
	public Transform winBGTransform;
	public Transform story;
	public Transform menu;
	public Transform building;
	public Transform buildingBackground;
	public Transform earth;
	public Transform achievement;
	public Transform allAchievement;
	public Transform lockLayer;
	public Transform statisticsLayer;
	public Transform achievementInGame;
	public Transform optionsLayer;
	public Transform cardBackLayer;
	public Transform backgroundSelectLayer;
	public int sceneIndex;
	//public SelectCardBackController scbController;

	private string[] countryNames = { "france", "italy", "britain", "usa", "egypt", "india", "japan", "china", "1-2" };

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void initUI(){
		if (sceneIndex == 0) {
			AssetBundle asset = getAssetBundle ("otherbackground");
			menu.GetComponent<Image> ().sprite = asset.LoadAsset<Sprite> ("Assets/Resources/Sprites/other/menuBackground_img.png");
			story.GetComponent<Image> ().sprite = asset.LoadAsset<Sprite> ("Assets/Resources/Sprites/other/story_img.png");
			statisticsLayer.GetComponent<Image> ().sprite = asset.LoadAsset<Sprite> ("Assets/Resources/Sprites/other/statisticsBack.png");
			asset.Unload (false);
		} else if (sceneIndex == 1) {
			AssetBundle asset = getAssetBundle ("backgrounds");
			//winBGTransform.GetComponent<Image> ().sprite = getSpriteFromABFile ("otherbackground", "Assets/Resources/Sprites/other/victoryBackground_img.png");
			for (int i = 0; i < 9; i++) {
				//scbController.backgroundBtnList [i].GetComponent<Image> ().sprite = asset.LoadAsset<Sprite> ("Assets/Resources/Sprites/backgrounds/" + countryNames [i] + ".png");
			}
			buildingBackground.GetComponent<Image> ().sprite = asset.LoadAsset<Sprite> ("Assets/Resources/Sprites/backgrounds/1-2.png");
			asset.Unload (false);
			AssetBundle assetBack = getAssetBundle ("cardback");
			//winBGTransform.GetComponent<Image> ().sprite = getSpriteFromABFile ("otherbackground", "Assets/Resources/Sprites/other/victoryBackground_img.png");
			for (int i = 0; i < 8; i++) {
				for (int j = 0; j < 4; j++) {
					//Image image= scbController.countryBtnList [i].GetChild(j).GetComponent<Image> ();
					//string st = "Assets/Resources/Sprites/cardBack/" + countryNames [i] + "/" + (j+1) + ".png";
					//Sprite s= assetBack.LoadAsset<Sprite> ("Assets/Resources/Sprites/cardBack/" + countryNames [i] + "/" + (j+1) + ".png");
					//scbController.countryBtnList [i].GetChild(j).GetComponent<Image> ().sprite = assetBack.LoadAsset<Sprite> ("Assets/Resources/Sprites/cardBack/" + countryNames [i] + "/" + (j+1) + ".png");
				}
			}
			assetBack.Unload (false);
			AssetBundle assetCover = getAssetBundle ("topcover");
			//winBGTransform.GetComponent<Image> ().sprite = getSpriteFromABFile ("otherbackground", "Assets/Resources/Sprites/other/victoryBackground_img.png");
			for (int i = 0; i < 9; i++) {
				Sprite s = assetCover.LoadAsset<Sprite> ("Assets/Resources/Sprites/topCover/cover" + i + ".png");
				//scbController.topCoverList.Add (assetCover.LoadAsset<Sprite> ("Assets/Resources/Sprites/topCover/cover" + i + ".png"));
			}
			assetCover.Unload (false);
			AssetBundle asset1 = getAssetBundle ("otherbackground");
			achievement.GetComponent<Image> ().sprite = asset1.LoadAsset<Sprite> ("Assets/Resources/Sprites/other/targetBackground_img.png");
			allAchievement.GetComponent<Image> ().sprite = asset1.LoadAsset<Sprite> ("Assets/Resources/Sprites/other/allStarBackground_img.png");
			earth.GetComponent<Image> ().sprite = asset1.LoadAsset<Sprite> ("Assets/Resources/Sprites/other/earthBackground_img.png");
			lockLayer.GetComponent<Image> ().sprite = asset1.LoadAsset<Sprite> ("Assets/Resources/Sprites/other/lockBackground_img.png");
			building.GetComponent<Image> ().sprite = asset1.LoadAsset<Sprite> ("Assets/Resources/Sprites/other/buildings_img.png");
			winBGTransform.GetComponent<Image> ().sprite = asset1.LoadAsset<Sprite> ("Assets/Resources/Sprites/other/victoryBackground_img.png");
			backgroundSelectLayer.GetComponent<Image> ().sprite = asset1.LoadAsset<Sprite> ("Assets/Resources/Sprites/other/selectBack.png");
			achievementInGame.GetComponent<Image> ().sprite = asset1.LoadAsset<Sprite> ("Assets/Resources/Sprites/other/pop-achieve.png");
			optionsLayer.GetComponent<Image> ().sprite = asset1.LoadAsset<Sprite> ("Assets/Resources/Sprites/other/setting_back.png");
			cardBackLayer.GetComponent<Image> ().sprite = asset1.LoadAsset<Sprite> ("Assets/Resources/Sprites/other/selectBack.png");
			asset1.Unload (false);
		}
	}
	private Sprite getSpriteFromABFile(string ABFileName,string spritePath){
		string abPath = LocationDataController.GetFilePath ("ABFile", ABFileName);
		AssetBundle asset = AssetBundle.LoadFromFile (abPath);
		//Sprite sprite = asset.LoadAsset<Sprite> ("Assets/Resources/Sprites/backgrounds/china.png");
		Sprite sprite = asset.LoadAsset<Sprite> (spritePath);
		return sprite;
	}
	private AssetBundle getAssetBundle(string ABFileName){
		string abPath = LocationDataController.GetFilePath ("ABFile", ABFileName);
		AssetBundle asset = AssetBundle.LoadFromFile (abPath);
		return asset;
	}
}
