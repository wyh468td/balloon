using UnityEngine;
using System.Collections;

public class Constants : MonoBehaviour {
	
}

public enum SpaceType{
	Water = 0,
	Sky,
	Aether
}

public enum MoveMultipleActionType
{
	ToTarget,
	UpAndDown,
	Freedom
}

public enum moveType{
	move,
	deal,
	finish
}

public enum ItemType{
	coin = 0,
	score  = 1,
	win  = 2,
	winCombo  = 3,
	button  = 4,
	firstCard  = 5,
	twoTypeFirst  = 6,
	fourTypeFirst  = 7,
	oneTypeTime = 8,
	twoTypeTime = 9,
	fourTypeTime = 10,
	timeToTime = 11
}

public enum ErrorType{
	dealError,
	backError,
	touchError
}

public enum GameLanguage{
	CH,
	EN
}