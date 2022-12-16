using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class TargetsManager : MonoBehaviour
{
    public string jsonTargetsPath;
    public List<StarRow> starRows;
    public List<SkillRow> skillsRows;

    bool isSaved;
    
    void Start()
    {
        #if UNITY_EDITOR
            jsonTargetsPath = Application.dataPath;
        #else
            jsonTargetsPath = Application.persistentDataPath;
        #endif
        jsonTargetsPath += "/targets.json";
    }

    void Awake()
    {
        // starRows = GameObject.FindGameObjectsWithTag("RowStar").Select( star => star.GetComponent<StarRow>() ).ToList();
        starRows = transform.GetComponentsInChildren<StarRow>(true).ToList();
        skillsRows = transform.GetComponentsInChildren<SkillRow>(true).ToList();

        foreach (StarInfo s in TargetsInfo.StarsInfo) starRows[s.idByType].Restore(s);
        foreach (SkillInfo s in TargetsInfo.SkillsInfo) skillsRows[s.idByType].Restore(s);
        
        LoadTargets();
    }


    [System.Serializable]
    public class SaveData
    {
        public List<Star.SaveTarget> stars;
        public List<Skill.SaveTarget> skills;
    }

    public void LoadTargets()
    {
        if (File.Exists(jsonTargetsPath))
        {
            string json = File.ReadAllText(jsonTargetsPath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            data.stars.ForEach( obj => {
                starRows[ obj.infoIndex ].obtained = obj.obtained;
            });
            data.skills.ForEach( obj => {
                skillsRows[ obj.gameIndex ].obtained = obj.obtained;
            });
        }
    }

}
