using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashLevelLoad : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        Invoke("LoadFirstLevel", 3f);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
}
