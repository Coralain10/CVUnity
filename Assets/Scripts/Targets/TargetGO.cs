using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Target Game Object on Platform
public class TargetGO : Target
{
    Text txtName;
    SpriteRenderer spriteRdr;
    protected TargetsManager tManager;
    protected GameObject dialog;
    protected GameObject objToCollide;
    protected Animator dialogAnim;
    public int infoIndex { get; protected set; }
    public int gameIndex { get; protected set; }

    protected virtual void Awake()
    {
        tManager     = GameObject.Find("Dialogs In Game").GetComponent<TargetsManager>();
        dialog       = transform.Find("Dialog").gameObject;
        dialogAnim   = dialog.GetComponent<Animator>();
        objToCollide = transform.Find("Object").gameObject;
        dialog.SetActive(false);
    }
    
    public virtual SaveTarget Tokenize() //TargetInfo info
    {
        SaveTarget target = new SaveTarget();
        target.gameIndex  = gameIndex;
        target.infoIndex  = infoIndex;
        target.obtained   = obtained;
        target.parentName = transform.parent.name;
        target.position   = transform.position;
        return target;
    }

    protected override void OnObtainedChange(){
        if(_obtained) 
        {
            objToCollide.SetActive(false);
            dialog.SetActive(true);
            dialogAnim.Play("FadingUp");
            StartCoroutine( DialogHide() );
        }
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
        infoIndex = info.id;
        gameIndex = info.idByType;

        txtName = transform.Find("Dialog/Canvas/Name").gameObject.GetComponent<Text>();
        txtName.text = info.name;

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

    private IEnumerator DialogHide()
    {
        yield return new WaitForSeconds(3);
        dialogAnim.Play("HidingUp");
        yield return new WaitForSeconds(0.5f);
        // Destroy(gameObject, 0.5f);
        gameObject.SetActive(false);
    }
}
