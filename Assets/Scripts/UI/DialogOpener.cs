using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogOpener : MonoBehaviour
{
    public Button button;
    public GameObject dialog;

    void Start()
    {
        button = GetComponent<Button>();
        Debug.Log(button.name);
        string name = button.name.Split(' ')[1];
        Debug.Log(name);
        dialog = GameObject.Find("Dialog "+name);
        button.onClick.AddListener(OpenDialog);
    }

    public void OpenDialog()
    {
        Debug.Log("Opening");
        dialog.SetActive(true);
        Time.timeScale = 0;
    }
}
