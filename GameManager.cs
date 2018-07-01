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

public class GameManager : MonoBehaviour
{
    public List<Bird> birds;
    public List<Pig> pigs;
    public List<GameObject> stars;
    public GameObject lose;
    public GameObject win;

    public static GameManager _instance;

    private int starsNum;
    private int totalNum = 10;

    private void Awake()
    {
        _instance = this;
        Initialized();
    }
   
    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0)
            {
                birds[i].enabled = true;
                birds[i].spring.enabled = true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].spring.enabled = false;
            }
        }
    }
    public void NextBird()
    {
        if (pigs.Count > 0)
        {
            if (birds.Count > 0)
            {
                //下一只
                Initialized();
            }
            else
            {
                //输了
                lose.SetActive(true);
            }
        }
        else
        {
            //赢了
            win.SetActive(true);

        }
    }
    public void ShowStar()
    {
        StartCoroutine(show());
    }
    IEnumerator show()
    {
        for (; starsNum < birds.Count + 1; starsNum++)
        {
            if (starsNum >= stars.Count) break;
            stars[starsNum].SetActive(true);
            yield return new WaitForSeconds(.5f);
        }
        
    }

    public void RePlay()
    {
        SaveData();
        SceneManager.LoadScene(2);
    }

    public void Home()
    {
        SaveData();
        SceneManager.LoadScene(1);
    }

    public void SaveData()
    {
        if(starsNum >=  PlayerPrefs.GetInt(PlayerPrefs.GetString("nowLevel")))
        {
            PlayerPrefs.SetInt(PlayerPrefs.GetString("nowLevel"), starsNum);
            Debug.Log("Save");
        }
        int sum = 0;
        for (int i = 0; i < totalNum; i++)
        {
            sum += PlayerPrefs.GetInt("Level"+ i.ToString());
           
        }
        PlayerPrefs.SetInt("totalNum", sum);
    }
}

