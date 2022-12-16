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
    public List<Skill> skills; //

    bool isSaved;
    
    void Start()
    {
    }

    void Awake()
    {
        isSaved = false;
        // stars = transform.GetComponentsInChildren<Star>(true).ToList();
        stars = GameObject.FindGameObjectsWithTag("Star").Select( star => star.GetComponent<Star>() ).ToList();
        skills = GameObject.FindGameObjectsWithTag("Skill").Select( skill => skill.GetComponent<Skill>() ).ToList();
        foreach (StarInfo s in TargetsInfo.StarsInfo) stars[s.id].RestoreInfo(s);
        foreach (SkillInfo s in TargetsInfo.SkillsInfo) skills[s.id].RestoreInfo(s);
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
        // data.stars = stars.Select( obj => obj.Tokenize() ).ToList();
        data.stars = new List<Star.SaveTarget>(TargetsInfo.StarsInfo.Length);
        data.skills = new List<Skill.SaveTarget>(TargetsInfo.SkillsInfo.Length);

        foreach (StarInfo s in TargetsInfo.StarsInfo) data.stars[s.id] = stars[s.id].Tokenize(s);
        foreach (SkillInfo s in TargetsInfo.SkillsInfo) data.skills[s.id] = skills[s.id].Tokenize(s);

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
            data.skills.ForEach( obj => { skills[ obj.gameIndex ].RestoreObj(obj); });
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
