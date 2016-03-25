using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R Pressed.");
            SceneManager.LoadScene(0);
        }
	}
}
