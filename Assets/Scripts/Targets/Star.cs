using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Star : TargetGO
{
  // public StarInfo starInfo;
  //STAR ROW
  // void Awake()
  // {
  // }

  public override void RestoreObj(SaveTarget target)
  {
    base.RestoreObj(target);
  }
  public void RestoreInfo(StarInfo starInfo)
  {
    RestoreInfo((TargetInfo)starInfo);
  }


  // RestoreObject(SaveTarget target)
}