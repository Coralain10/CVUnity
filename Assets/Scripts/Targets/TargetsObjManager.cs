using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class TargetsObjManager : MonoBehaviour
{
    [SerializeField] TargetsManager targetsManager;
    public List<Star> stars; //
    // public Skill[] skills;

    bool isSaved;
    
    void Start()
    {
    }

    void Awake()
    {
        isSaved = false;
        stars = GameObject.FindGameObjectsWithTag("Star").Select( star => star.GetComponent<Star>() ).ToList();
        // stars = transform.GetComponentsInChildren<Star>(true).ToList();
        foreach (StarInfo s in TargetsInfo.StarsInfo) stars[s.id].RestoreInfo(s);
        // skills = GameObject.FindGameObjectsWithTag("Skill");
        LoadTargets();
    }

    void Update()
    {
        if(!isSaved)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                SaveTargets();
            }
        }
    }

    public void SaveTargets()
    {
        TargetsManager.SaveData data = new TargetsManager.SaveData();
        data.stars = new List<Star.SaveTarget>(TargetsInfo.StarsInfo.Length);
        foreach (StarInfo s in TargetsInfo.StarsInfo) data.stars[s.id] = stars[s.id].Tokenize(s);
        // data.stars = stars.Select( obj => obj.Tokenize() ).ToList();
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(targetsManager.jsonTargetsPath, json);
        Debug.Log("json " + json);
    }

    public void LoadTargets()
    {
        if (File.Exists(targetsManager.jsonTargetsPath))
        {
            string json = File.ReadAllText(targetsManager.jsonTargetsPath);
            TargetsManager.SaveData data = JsonUtility.FromJson<TargetsManager.SaveData>(json);
            data.stars.ForEach( obj => { stars[ obj.gameIndex ].RestoreObj(obj); });
        }
    }

    // void OnDisable()
    // {
    //     SaveTargets();
    // }


// public void SaveColorClicked()
// {
//     MainManager.Instance.SaveColor();
// }

// public void LoadColorClicked()
// {
//     MainManager.Instance.LoadColor();
//     ColorPicker.SelectColor(MainManager.Instance.TeamColor);
// }

}
