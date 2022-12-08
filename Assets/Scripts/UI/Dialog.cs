using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    // private Button btnClose;
    // public GameObject dialog;

    protected virtual void Start()
    {
        // btnClose = GetComponent<Button>();
        // Debug.Log(btnClose.name);
        // dialog = transform.parent.parent.gameObject;
        // btnClose.onClick.AddListener(CloseDialog);
    }

    public void CloseDialog()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenDialog()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
