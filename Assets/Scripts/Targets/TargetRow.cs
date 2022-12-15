using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetRow : Target
{
    Text txtName;

    public virtual void Restore(TargetInfo info)
    {
        txtName = transform.Find("Name").gameObject.GetComponent<Text>();
        // gameIndex = info.id;
        txtName.text = info.name;
        // this.obtained = obtained;
        imageChildPath = "Mask/Icon";
        RestoreImage(info.spriteName);
        // Debug.Log("Row: " + image + " | " + txtName);
    }
}
