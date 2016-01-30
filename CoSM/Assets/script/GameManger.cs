using UnityEngine;
using System.Collections;

public class GameManger : MonoBehaviour {

    public GameObject Player;
    public GameObject canvasPopup;
    public GameObject inGameCanvas;
    public static bool isPlayGame = true;
    
    // Use this for initialization
    void Awake()
    {      
        DontDestroyOnLoad(canvasPopup);
        DontDestroyOnLoad(inGameCanvas);        
       // if(GameObject.find)
        GameObject a = Instantiate(canvasPopup);
        a.name = "popUpCavas";
        GameObject b = Instantiate(inGameCanvas);
        b.name = "InGameCanvas";

    }
    void Start()
    {
        Instantiate(Player);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
