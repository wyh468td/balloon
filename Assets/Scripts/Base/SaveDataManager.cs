using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

//各个国家
public class LevelDataInfo
{
	public bool isLocked = true;
	// 最佳步数
	public int best = 0;
	// 总星数
	public int starCount = 30;
	// 获得星数
	public int clearCount = 0;
	// 解锁需要上关星数
	public int needStarCount = 15;
	// 解锁需要金币数
	public int needCoin = 100;
	// 当前卡背
	public int cardBack = 0;
	// 当前背景
	public int backgroundPicture = 0;
	// 所有成就
	//public List<AchievementScript> achievementList;
	// 当前成就 1 2 3
	//public  List<AchievementScript> currentAchievementList;
	// wancheng 
	//public List<AchievementScript> achievementFinishList;
	public int[] cardBackStatics = { 0, 0, 0, 0 };
	public int[] backgroundStatics = { 0, 0, 0, 0 };
	public bool isFirst = true;
}
//三种模式
public class PackageDataInfo
{
	// 关卡是否锁着
	public bool isLocked = true;
	// 总星数
	public int starCount = 0;
	// 总过关数
	public int clearCount = 0;
	// 本关模式 1/2/4 色 对应 0,1,2
	public int playType = 0;
	//本模式游戏次数
	public int playNum = 0;
	//胜利次数
	public int successNum = 0;
	//失败次数
	public int failureNum = 0;
	//最高连胜次数
	public int comboSuccessNum = 0;
	//最高连败次数
	public int comboFailureNum = 0;
	//当前连胜次数
	public int currentComboNum = 0;
	//当前连败次数
	public int currentComboFNum = 0;
	//最高得分
	public int bestScore = 0;
	//最少移动次数
	public int bestMove = 0;
	//最快时间
	public string bestTime = "00:00:00";
}

public class SaveData
{
	// 音效开关
	public bool isSoundOn = true;
	// 音乐开关
	public bool isMusicOn = true;
	// 目前所在包位置
	public int curPackage = 1;
	// 目前所在关卡
	public int curLevel = 0;
	// first start game
	public bool firstGame = true;
	// first start game
	public bool isFirstCoin = true;
	// 新手引导
	public bool isGuideOver = false;
	// 开始游戏时是否更新
	public bool isGameUpdateAwake = false;
	// 提示总数
	public int hintCount = 3;
	// 返回次数
	public int returnCount = 0;
	// 刷关次数
	public int levelInCount = 0;
	// 使用刷新次数
	public int useRefreshCount = 0;
	// 三个模式信息数组
	public List<PackageDataInfo> packageList;
	// 关卡信息数组
	public List<LevelDataInfo> levelList;
	// 金币总数
	public int coinAllCount = 0;
	// 自由模式卡背
	public string currentCardBack = "81";
	// 自由模式背景
	public int currentBackGround = 0;
	public string newCardBack = "01";
}

public class SaveDataManager : MonoBehaviour
{
	public GameSaveDataController saveDataController;
	public LocationDataController locationDataController;
	public SaveData myData = null;
	private int[] clearStar = { 1, 6, 10, 15, 20, 25, 20, 25 };
	private int[] allStar = { 12, 20, 22, 30, 40, 27, 40, 49 };
	private int[] needCoin = { 100, 2000, 5000, 10000, 20000, 30000, 50000, 80000 };
	//public PackageDataController pDataController;

	void Awake ()
	{
		string jsonStr;
		if (!saveDataController.isSaveDataExist ()) {
			myData = new SaveData ();
			this.initData ();
			//将对象转成json格式的字符串
			jsonStr = JsonMapper.ToJson (myData);
			//JSONObject jo = new JSONObject (myData);
			//jsonStr = jo.ToString ();
//			Debug.Log ("save data: " + jsonStr);
			saveDataController.saveData (jsonStr);
		} else {
			//resetSaveData ();

			myData = JsonMapper.ToObject<SaveData> (saveDataController.getSaveDataContent ());
			if (myData.packageList.Count > 1 && myData.packageList [1].isLocked == false && myData.isGameUpdateAwake == false) {
				myData.isGameUpdateAwake = true;
				this.save ();
			}
		}
	}
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void initData ()
	{
		myData.packageList = new List<PackageDataInfo> ();
		for (int j = 0; j < 3; j++) {
			PackageDataInfo package = new PackageDataInfo ();
			myData.packageList.Add (package);
			package.isLocked = false;
			package.playType = j;
		}
		myData.levelList = new List<LevelDataInfo> ();
		for (int i = 0; i < 8; i++) {
			LevelDataInfo ldi = new LevelDataInfo ();
			ldi.needStarCount = clearStar [i];
			ldi.starCount = allStar [i];
			ldi.needCoin = needCoin [i];
			ldi.cardBack = 1;
			//ldi.currentAchievementList = new List<AchievementScript> ();
			//ldi.achievementList = new List<AchievementScript> ();
			//ldi.achievementFinishList = new List<AchievementScript> ();
			myData.levelList.Add (ldi);
		}
		//getAchievements ();
	}

	public void save ()
	{
		saveDataController.saveData (JsonMapper.ToJson (myData));
	}
	public void resetSaveData(){
		myData = new SaveData ();
		initData ();
		this.save ();
	}
	public void resetTypeSaveData(int typeIndex){
		PackageDataInfo package = new PackageDataInfo ();
		package.isLocked = false;
		package.playType = typeIndex;
		myData.packageList.RemoveAt (typeIndex);
		myData.packageList.Insert (typeIndex,package);
		this.save ();
	}
	/*
	public void resetSaveData ()
	{
		if (pDataController.packages.Count > myData.packageList.Count) { // 有更新
			for (int i = 0; i < pDataController.packages.Count; i++) {
				if (myData.packageList.Count == i) {
					PackageData pData = pDataController.packages [i];
					PackageDataInfo package = new PackageDataInfo ();
					myData.packageList.Add (package);
					package.isLocked = true;
					package.levelList = new List<LevelDataInfo> ();
					for (int j = 0; j < pData.levelCount; j++) {
						package.levelList.Add (new LevelDataInfo ());
					}
				}
			}
			save ();
		}
	}

	public void updataPackageData (int packageId)
	{
		PackageDataInfo info = myData.packageList [packageId - 1];
		int clearCount = 0;
		int starCount = 0;
		for (int i = 0; i < info.levelList.Count; i++) {
			if (info.levelList [i].starCount != 0) {
				clearCount++;
				starCount += info.levelList [i].starCount;
			}
		}
		info.clearCount = clearCount;
		info.starCount = starCount;
		this.save ();
	}
*/
	public int getAllStar ()
	{
		int allStar = 0;
		for (int i = 0; i < myData.packageList.Count; i++) {
			allStar += myData.packageList [i].starCount;
		}
		return allStar;
//		return 9999999;
	}
	/*
	public void getAchievements(){
		JSONObject json = new JSONObject (locationDataController.getDataContentFromFile ("LevelData", "2"));
		JSONObject jsonAllAchievement = json["achievement"];
		for (int i = 0; i < jsonAllAchievement.list.Count; i++) {
			JSONObject jsonLevelAchievement = jsonAllAchievement [i];
			if (i.ToString().Equals(jsonLevelAchievement ["levelNum"].ToString())) {
				JSONObject jsonAchievementList = jsonLevelAchievement ["data"];
				for (int j = 0; j < jsonAchievementList.list.Count; j++) {
					AchievementScript achievementScript = JsonMapper.ToObject<AchievementScript> (jsonAchievementList [j].ToString());
					myData.levelList [i].achievementList.Add (achievementScript);
				}
			}
		}
	}
	*/
}
