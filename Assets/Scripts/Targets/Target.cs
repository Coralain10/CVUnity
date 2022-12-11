using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Target : MonoBehaviour
{
    public Image image;
    public string targetName;
    public string description;
    public bool obtained;
    public byte progress;

    protected virtual void Awake()
    {
    }

    public virtual SaveTarget Tokenize()
    {
        SaveTarget target  = new SaveTarget();
        target.parentName  = transform.parent.name;
        target.position    = transform.position;
        target.spriteName  = image.sprite.name;
        target.name        = targetName;
        target.description = description;
        target.progress    = progress;
        target.obtained    = obtained;
        return target;
    }
 
    public virtual void RestoreFromToken(SaveTarget target, bool setPosition = true)
    {
        if(target == null) throw new System.ArgumentNullException("target");
        //omitir colocar posición si se carga desde info
        if(setPosition)
        {
            transform.SetParent( GameObject.Find(target.parentName).transform ); //, false
            transform.position = target.position;
        }
        image.sprite       = Resources.Load<Sprite>(target.spriteName);
        targetName         = target.name;
        description        = target.description;
        progress           = target.progress;
        obtained           = target.obtained;
        // if (target.obtained) SetActive(false); //TODO set transparencia de Image a 0
    }
    
    [System.Serializable]
    public class SaveTarget
    {
        public string parentName;
        public Vector3 position;
        public string spriteName;
        public string name;
        public string description;
        public byte progress;
        public bool obtained;
    }
}
