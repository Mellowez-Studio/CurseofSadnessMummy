using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using MasterDJ;
public class MainMenuControl : ControlVoulme {

	private GameObject optPanel;
	private GameObject crePanel;

	private Slider soundSli;

	private Text volumeTxt;
	public AudioClip soundClick;
	public AudioClip soundBG;

	void Start () {
		optPanel = GameObject.Find ("Option_panel");
		crePanel = GameObject.Find ("Credit_panel");
		DJ.PlayAudioBackground (soundBG,null,true);
		soundSli = GameObject.Find ("SoundAdjust").GetComponent<Slider> ();

		volumeTxt = GameObject.Find ("SoundLv_txt").GetComponent<Text> ();

		if (PlayerPrefs.HasKey ("Volume")) {
			soundSli.value = PlayerPrefs.GetFloat ("Volume");
			volumeTxt.text = soundSli.value.ToString ();
		} else {
			soundSli.value = 5;
			volumeTxt.text = "5";
		}
		mastersV = soundSli.value / 10f;
		//Volume = soundSli.value / 10f;
		UpdateDJ ();
		optPanel.SetActive (false);
		crePanel.SetActive (false);

		PlayerPrefs.DeleteAll ();
	}

	public void StartGame () {
		DJ.PlayAudioButton (soundClick,()=>Application.LoadLevel ("Room_0"));
	
	}

	public void Option () {
		DJ.PlayAudioButton (soundClick);
		if (!optPanel.activeSelf) {
			optPanel.SetActive (true);
		} else {
			optPanel.SetActive (false);
		}
	}

	public void AdjustSound () {
		DJ.PlayAudioButton (soundClick);
		mastersV = soundSli.value / 10f;
		//Volume = soundSli.value / 10f;
		volumeTxt.text = soundSli.value.ToString ();
		UpdateDJ ();
		PlayerPrefs.SetFloat ("Volume", soundSli.value);
	}

	public void Credit () {
		DJ.PlayAudioButton (soundClick);
		if (!crePanel.activeSelf) {
			crePanel.SetActive (true);
		} else {
			crePanel.SetActive (false);
		} 
	}

	
}
