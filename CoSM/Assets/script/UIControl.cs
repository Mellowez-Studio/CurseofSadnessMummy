using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour {
	
	public static bool isPause = false;

	public static float hour;
	public static float minute;

	private GameObject mapPanel;

	private Image timeUI;

	private Button[] slot = new Button[4];

	private Text timeTxt;

	private float time = 1800f;
	private float timeLeft;

	private bool[] gain = new bool[4];
	// Use this for initialization
	void Start () {
		mapPanel = GameObject.Find ("Map_panel");

		timeUI = GameObject.Find ("CurseTime").GetComponent<Image> ();

		timeTxt = GameObject.Find ("Time_txt").GetComponent<Text> ();

		for (int i = 1; i <= 4; i++) {
			slot[i - 1] = GameObject.Find ("Slot_" + i).GetComponent<Button> ();
		}

		mapPanel.SetActive (false);

		isPause = false;
		hour = 0;
		minute = 0;

		if (!PlayerPrefs.HasKey ("Slot1")) {
			PlayerPrefs.SetInt ("Slot1", 0);
			PlayerPrefs.SetInt ("Slot2", 0);
			PlayerPrefs.SetInt ("Slot3", 0);
			PlayerPrefs.SetInt ("Slot4", 0);

			for (int i = 0; i < 4; i++) {
				gain[i] = false;
			}
		} else {
			for (int i = 0; i < 4; i++) {
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
		print (gain [i]);
	}

	public void Map () {
		if (mapPanel.activeSelf) {
			mapPanel.SetActive (false);
			return;
		}

		mapPanel.SetActive (true);
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
				
				if (minute >= 60) {
					minute = 0;
					hour++;

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
