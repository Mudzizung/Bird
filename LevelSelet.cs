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
using UnityEngine.SceneManagement;
public class LevelSelet : MonoBehaviour
{
    public bool isSelect = false;

    public Sprite levelBG;

    private Image image;

    public GameObject[] stars;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void Start()
    {
        if (transform.parent.GetChild(0).name == gameObject.name)
        {
            isSelect = true;
        }
        else
        {//判断当前关卡是否可以选择
            int beforeNum = int.Parse(gameObject.name)-1;
            if (PlayerPrefs.GetInt("Level" + beforeNum.ToString()) >0)
            {
                isSelect = true;
            }
        }
        if (isSelect)
        {
            image.sprite = levelBG;
            int count = PlayerPrefs.GetInt("Level" + gameObject.name);

            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    stars[i].SetActive(true);
                }
            }
        }
    }

    public void CanSelet()
    {
        if (isSelect)
        {
            PlayerPrefs.SetString("nowLevel","Level"+ gameObject.name);
            SceneManager.LoadScene(2);
        }
    }
}

