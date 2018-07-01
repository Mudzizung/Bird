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

public class GetParent : MonoBehaviour
{
   // private Transform trans;
    private void Start()
    {
        //trans = this.transform;
       // Get(trans);
        //Move();
    }
    void Get(Transform trans)
    {
        Debug.Log("name:" + trans.name);
        if (trans.parent == null)
            return;
        trans = trans.parent;
        Get(trans);
    }

    private void Move()
    {
        float posx = transform.position.x;
        float newPosx = 150f;
        transform.position= new Vector2(Mathf.Lerp(posx, newPosx, .9f* Time.deltaTime),transform.position.y);
    }
}

