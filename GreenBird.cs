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

public class GreenBird : Bird
{
    public override void ShouSkill()
    {
        base.ShouSkill();
        Vector3 speed = rg.velocity;
        speed.x *= -1;
        rg.velocity = speed;
    }
    protected override void Next()
    {
        base.Next();
    }
}

