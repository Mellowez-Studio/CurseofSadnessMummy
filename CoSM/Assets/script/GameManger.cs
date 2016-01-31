using UnityEngine;
using System.Collections;

public class GameManger : MonoBehaviour {

    public GameObject Player;
    public GameObject canvasPopup;
    public GameObject inGameCanvas;
    public static bool isPlayGame = true;
    public static int nextDoor = 0;
    public  static GameObject playerIns;
    static Transform InsPos;
    // Use this for initialization
    void Awake()
	{      DontDestroyOnLoad (this.gameObject);
       
        if (!GameObject.Find("popUpCavas"))
        {
            GameObject a = Instantiate(canvasPopup);
            a.name = "popUpCavas";
        }
		inGameCanvas  = Instantiate(inGameCanvas) as GameObject;
		inGameCanvas.name = "InGameCanvas";
        InsPos = GameObject.Find("PosIns_"+ nextDoor).transform;
		DontDestroyOnLoad(canvasPopup);
		DontDestroyOnLoad(inGameCanvas);
    }
    void Start()
    {
        playerIns = Instantiate(Player,InsPos.position,Quaternion.identity) as GameObject;
		DontDestroyOnLoad (playerIns);
    }

    public static void NextDoor(int index)
    {
        InsPos = GameObject.Find("PosIns_"+ index.ToString()).transform;
        playerIns.transform.position = InsPos.position;
      
    }
    public static void PreLoad()
    {
        playerIns.transform.position = new Vector3(100f,100f,100f);
    }
}
