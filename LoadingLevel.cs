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

public class LoadingLevel : MonoBehaviour
{
    private void Awake()
    {
        Instantiate(Resources.Load(PlayerPrefs.GetString("nowLevel")));
    }
}

