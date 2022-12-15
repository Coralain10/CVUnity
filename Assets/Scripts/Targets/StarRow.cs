using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarRow : TargetRow
{
    Text txtDescription;

    public void Restore(StarInfo info)
    {
        txtDescription = transform.Find("Description").gameObject.GetComponent<Text>();
        txtDescription.text = info.description;
        base.Restore(info);
    }
}
