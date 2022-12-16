using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Target Game Object on Platform
public class TargetGO : Target
{
    Text txtName;
    SpriteRenderer spriteRdr;
    
    public virtual SaveTarget Tokenize(TargetInfo info)
    {
        SaveTarget target = new SaveTarget();
        target.gameIndex  = info.id;
        target.infoIndex  = info.idByType;
        target.obtained   = obtained;
        target.parentName = transform.parent.name;
        target.position   = transform.position;
        return target;
    }

    protected override void OnObtainedChange(){
        if(!_obtained) gameObject.SetActive(false);
    }
    
    public virtual void RestoreObj(SaveTarget target)
    {
        if(target == null) throw new System.ArgumentNullException("target");
        obtained           = target.obtained;
        // transform.SetParent( GameObject.Find(target.parentName).transform ); //, false
        transform.position = target.position;
    }

    public virtual void RestoreInfo(TargetInfo info)
    {
        txtName = transform.Find("Dialog/Canvas/Name").gameObject.GetComponent<Text>();
        txtName.text = "+1 " + info.name;

        spriteRdr = transform.Find("Object/Image").gameObject.GetComponent<SpriteRenderer>();
        spriteRdr.sprite = LoadSprite(info.spriteName);
    } 
    
    [System.Serializable]
    public class SaveTarget
    {
        public bool obtained;
        public int gameIndex;
        public int infoIndex;
        public string parentName;
        public Vector3 position;
    }
}
