using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class SoundManager : MonoBehaviour
{
	public int pageIndex = 0; 
	// touch button
	public AudioSource button;
	// turn card
	public AudioSource move;
	// finish one game
	public AudioSource win;
	// plane arrival
	public AudioSource tintOver;
	// show coin 
	public AudioSource coinShow;
	// deal the cards
	public AudioSource dealCard;
	// first deal cards
	public AudioSource newDeal;
	// the card up
	public AudioSource cardUp;
	// the card down
	public AudioSource cardDown;
	// background music 
	public AudioSource backgroundMusic;
	// card can't move
	public AudioSource unMove;

	public AudioSource wholeCard;
	// click the card
	public AudioSource clickCard;
	// click the arrow icon
	public AudioSource clickArrow;
	// 
	public AudioSource hint;
	public AudioSource achieve;
	// Use this for initialization
	void Start ()
	{
	
	}
	// Update is called once per frame
	void Update ()
	{
	
	}
	public void setSoundEnabled (bool isEnabled)
	{
		button.mute = !isEnabled;
		move.mute = !isEnabled;
		win.mute = !isEnabled;
		coinShow.mute = !isEnabled;
		dealCard.mute = !isEnabled;
		newDeal.mute = !isEnabled;
		cardUp.mute = !isEnabled;
		cardDown.mute = !isEnabled;
		unMove.mute = !isEnabled;
		wholeCard.mute = !isEnabled;
		clickCard.mute = !isEnabled;
		clickArrow.mute = !isEnabled;
		hint.mute = !isEnabled;
		achieve.mute = !isEnabled;
	}
	public void setMusicEnabled (bool isEnabled)
	{
		backgroundMusic.mute = !isEnabled;
	}
	public void playButtonSound ()
	{
		button.Play ();
	}
	public void playCoinSound ()
	{
		coinShow.Play ();
	}
	public void playDealCardSound ()
	{
		dealCard.Play ();
	}
	public void playNewDealCardSound ()
	{
		newDeal.Play ();
	}
	public void playMoveSound ()
	{
		move.Play ();
		/*
		if (!move.isPlaying) {
			move.Play ();
		}
		*/
	}
	public void playWinSound ()
	{
		win.Play ();
	}

	public void playTintOver ()
	{
		tintOver.Play ();
	}
	public void playCardUpSound ()
	{
		cardUp.Play ();
	}
	public void playCardDownSound ()
	{
		cardDown.Play ();
	}
	public void playBackground ()
	{
		if (backgroundMusic.isPlaying) {
		} else {
			backgroundMusic.Play ();
		}
	}
	public void playUnMove(){
		unMove.Play ();
	}
	public void playWholeCard(){
		wholeCard.Play ();
	}
	public void playClickCard(){
		if (clickCard.isPlaying) {
			clickCard.Stop ();
			clickCard.Play ();
		} else {
			clickCard.Play ();
		}
	}
	public void playClickArrow(){
		clickArrow.Play ();
	}
	public void playHint(){
		hint.Play ();
	}
	public void playAchieve(){
		achieve.Play ();
	}
}
