using UnityEngine;
using System.Collections;

public class GameManger : MonoBehaviour {

    public GameObject Player;
    public GameObject canvasPopup;
    public GameObject inGameCanvas;
    public static bool isPlayGame = true;

    public Transform InsPos;
    // Use this for initialization
    void Awake()
    {      
        DontDestroyOnLoad(canvasPopup);
        DontDestroyOnLoad(inGameCanvas);
        if (!GameObject.Find("popUpCavas"))
        {
            GameObject a = Instantiate(canvasPopup);
            a.name = "popUpCavas";
        }
        GameObject b = Instantiate(inGameCanvas);
        b.name = "InGameCanvas";
        InsPos = GameObject.Find("PosIns_"+ Application.loadedLevel).transform;
    }
    void Start()
    {
        Instantiate(Player);//, InsPos.position,Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
