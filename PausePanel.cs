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

public class PausePanel : MonoBehaviour
{

    private Animator anima;

    //public GameObject pause;

    
    private void Awake()
    {
        anima = GetComponent<Animator>();
    }
    public void ReTry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }


    public void Pause()
    {
        anima.SetBool("IsClick", true);
        
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Resume()
    {
        Time.timeScale = 0;
    }

    public void PauseAnimEnd()
    {
       
    }

    public void ResumeAnimaEnd()
    {
        Time.timeScale = 1;
        anima.SetBool("IsClick", false);
    }
}

