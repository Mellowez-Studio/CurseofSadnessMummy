using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour {
	
	public static bool isPause = false;
	public static bool[] gain = new bool[7];

	public static float hour;
	public static float minute;

	private GameObject mapPanel;
	private GameObject itemPanel;

	private Image timeUI;

	private Button[] slot = new Button[7];

	private Text timeTxt;

	private float time = 1800f;
	private float timeLeft;
	// Use this for initialization
	void Start () {
		//mapPanel = GameObject.Find ("Map_panel");
		itemPanel = GameObject.Find ("Item_panel");

		timeUI = GameObject.Find ("CurseTime").GetComponent<Image> ();

		timeTxt = GameObject.Find ("Time_txt").GetComponent<Text> ();

		for (int i = 1; i <= 7; i++) {
			slot[i - 1] = GameObject.Find ("Slot_" + i).GetComponent<Button> ();
		}


		//mapPanel.SetActive (false);
		itemPanel.SetActive (false);

		isPause = false;

		if (PlayerPrefs.HasKey ("Minute")) {
			hour = PlayerPrefs.GetFloat ("Hour");
			minute = PlayerPrefs.GetFloat ("Minute");
		} else {
			hour = 0;
			minute = 0;
		}

		if (!PlayerPrefs.HasKey ("Slot1")) {
			PlayerPrefs.SetInt ("Slot1", 0);
			PlayerPrefs.SetInt ("Slot2", 0);
			PlayerPrefs.SetInt ("Slot3", 0);
			PlayerPrefs.SetInt ("Slot4", 0);
			PlayerPrefs.SetInt ("Slot5", 0);
			PlayerPrefs.SetInt ("Slot6", 0);
			PlayerPrefs.SetInt ("Slot7", 0);

			for (int i = 0; i < 7; i++) {
				gain[i] = false;
			}
		} else {
			for (int i = 0; i < 7; i++) {
				if (PlayerPrefs.GetInt ("Slot" + (i + 1)) == 0) {
					gain [i] = false;
				} else {
					gain [i] = true;
				}
			}
		}

		if (PlayerPrefs.HasKey ("CurseTime")) {
			StartCoroutine ("CountTime", PlayerPrefs.GetFloat ("CurseTime"));
		} else {
			StartCoroutine ("CountTime", time);
		}
	}

	public void itemSlot (int i) {
		if (!itemPanel.activeSelf) {
			if (gain [i]) {
				itemPanel.SetActive (true);
			}
		} else {
			itemPanel.SetActive (false);
		}
	}

	public void GetItem (int i) {
		PlayerPrefs.SetInt ("Slot" + i, 0);

		gain [i] = true;
	}

	public void Map () {
//		if (mapPanel.activeSelf) {
//			mapPanel.SetActive (false);
//			return;
//		}
//
//		mapPanel.SetActive (true);
	}

	public void StartStop () {
		if (!isPause) {
			isPause = true;
		} else {
			isPause = false;

			StartCoroutine ("CountTime", timeLeft);
		}
	}

	IEnumerator CountTime (int t) {
		timeUI.fillAmount = t / time;

		while (t > 0) {
			if (!isPause) {
				t--;

				if (hour < 10) {
					timeTxt.text = "0" + hour + " : ";
				} else {
					timeTxt.text = hour + " : ";
				}

				if (minute < 10) {
					timeTxt.text += "0" + minute;
				} else {
					timeTxt.text += minute;
				}

				yield return new WaitForSeconds (1f);

				timeUI.fillAmount = t / time;

				PlayerPrefs.SetFloat ("CurseTime", t);

				minute++;

				PlayerPrefs.SetFloat ("Minute", minute);
				
				if (minute >= 60) {
					minute = 0;
					hour++;

					PlayerPrefs.SetFloat ("Hour", hour);

					if (hour >= 24 && minute > 0) {
						hour = 0;
					}
				}
			} else {
				timeLeft = t;
				return false;
			}
		}
	}
}
