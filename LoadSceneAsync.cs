/***
  *Title:""��Ŀ
  *Description:
  *		����:
  *Author:D
  *Data:2018.03.18
  *
  *
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAsync : MonoBehaviour
{
	void Start () 
	{
        Screen.SetResolution(800, 500, false);
        Invoke("Load", 2);
	}
    private void Load()
    {
        SceneManager.LoadSceneAsync(1);
    }

}

