using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetRow : Target
{
    protected Image image;
    Text txtName;

    public virtual void Restore(TargetInfo info)
    {
        txtName = transform.Find("Name").gameObject.GetComponent<Text>();
        txtName.text = info.name;
        
        image = transform.Find("Mask/Icon").gameObject.GetComponent<Image>();
        image.sprite = LoadSprite(info.spriteName);

        obtained = false; //1° image restore
    }

    protected override void OnObtainedChange(){
        image.color = _obtained ? Color.white : new Color32(15,10,42,192);
    }

    // protected void setImageAlpha(float a)
    // {
    //     var tempColor = image.color;
    //     tempColor.a = a;
    //     image.color = tempColor;
    // }
}
