using UnityEngine;
using System.Collections;

public class menuC : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void RestartLevel()
    {
        Application.LoadLevel("as");
        gameObject.GetComponent<SetLocalEulerAngles>().speed = 0.5f;
    }

    public void NextLevel()
    {
        Application.LoadLevel("as");
    }

    public void HardLevel()
    {
        Application.LoadLevel("as");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
