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
using UnityEngine.UI;

public class MapSelet : MonoBehaviour
{
    public int startUnm = 0;
    private bool isSelet = false;
    public GameObject locks;
    public GameObject stars;
    public GameObject panel1;
    public GameObject map;

    public Text starText;
    public Text LockStar;
    //关
    private int startN = 1;
    public int endNum = 5;
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        LockStar.text = startUnm.ToString();
        if (PlayerPrefs.GetInt("totalNum", 0) >= startUnm)
        {
            isSelet = true;
        }
        if (isSelet)
        {
            locks.SetActive(false);
            stars.SetActive(true);
            //刷新星星数
            int count = 0;
            for (int i = startN; i < endNum; i++)
            {
                count += PlayerPrefs.GetInt("Level" + i.ToString(), 0);
            }

            starText.text = count.ToString() + "/10";

        }
    }

    public void Selet()
    {
        if (isSelet)
        {
            panel1.SetActive(true);
            map.SetActive(false);
        }
    }

    public void PanelSelet()
    {
        panel1.SetActive(false);
        map.SetActive(true);
    }
}

