﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuControl : MonoBehaviour {

	private GameObject optPanel;
	private GameObject crePanel;

	private Slider soundSli;

	private Text volumeTxt;

	void Start () {
		optPanel = GameObject.Find ("Option_panel");
		crePanel = GameObject.Find ("Credit_panel");

		soundSli = GameObject.Find ("SoundAdjust").GetComponent<Slider> ();

		volumeTxt = GameObject.Find ("SoundLv_txt").GetComponent<Text> ();

		if (PlayerPrefs.HasKey ("Volume")) {
			soundSli.value = PlayerPrefs.GetFloat ("Volume");
			volumeTxt.text = soundSli.value.ToString ();
		} else {
			soundSli.value = 5;
			volumeTxt.text = "5";
		}

		//Volume = soundSli.value / 10f;

		optPanel.SetActive (false);
		crePanel.SetActive (false);

		PlayerPrefs.DeleteAll ();
	}

	public void StartGame () {
		Application.LoadLevel ("Room_0");
	}

	public void Option () {
		if (!optPanel.activeSelf) {
			optPanel.SetActive (true);
		} else {
			optPanel.SetActive (false);
		}
	}

	public void AdjustSound () {
		//Volume = soundSli.value / 10f;
		volumeTxt.text = soundSli.value.ToString ();

		PlayerPrefs.SetFloat ("Volume", soundSli.value);
	}

	public void Credit () {
		if (!crePanel.activeSelf) {
			crePanel.SetActive (true);
		} else {
			crePanel.SetActive (false);
		} 
	}

	public void Shuffle (int[] alpha) {
		for (int i = 0; i < alpha.Length; i++) {
			int temp = alpha[i];
			int randomIndex = Random.Range(i, alpha.Length);
			alpha[i] = alpha[randomIndex];
			alpha[randomIndex] = temp;
			print (alpha[i]);
		}
	}
}
