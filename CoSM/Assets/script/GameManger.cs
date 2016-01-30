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
        Instantiate(canvasPopup);
        Instantiate(inGameCanvas);
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
