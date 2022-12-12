using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class TargetsManager : MonoBehaviour
{
    public string jsonTargetsPath;
    public List<Star> stars;
    // public Skill[] skills;
    [SerializeField] GameObject starPrefab;
    [SerializeField] GameObject skillPrefab;

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
        isSaved = false;
        stars = GameObject.FindGameObjectsWithTag("Star")
                .Select((obj, i) => {
                    Star star = obj.GetComponent<Star>();
                    star.targetIndex = i;
                    return star;
                })
                .ToList();
        // skills = GameObject.FindGameObjectsWithTag("Skill");
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
        else
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                LoadTargets();
            }
        }
    }


    [System.Serializable]
    class SaveData
    {
        public List<Star.SaveTarget> stars;
        public List<Skill.SaveTarget> skills;
    }

    public void SaveTargets()
    {
        SaveData data = new SaveData();
        data.stars = stars.Select( obj => obj.Tokenize() ).ToList();
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(jsonTargetsPath, json);
        Debug.Log("json " + json);
    }

    public void LoadTargets()
    {
        if (File.Exists(jsonTargetsPath))
        {
            string json = File.ReadAllText(jsonTargetsPath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            // InstantiateByList(starPrefab, data.stars);
            // InstantiateByList(skillPrefab, data.skills);
        }
        // foreach (Star star in stars)
        // {
        //     Debug.Log("Found star: " + star.targetName + " " + star.description);
        //     GameObject starObj = Instantiate(starPrefab, star.position, star.transform.rotation, parentT);
        //     // Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);
        //     if (star.obtained) starObj.SetActive(false);
        //     starCount++;
        // }
        // foreach (Skill skill in skills)
        // {
        //     Debug.Log("Found skill: " + skill.targetName + " " + skill.description);
        // }
    }

    // void InstantiateByList(GameObject prefab, List<Target.SaveTarget> targets)
    // {
    //     targets.ForEach(obj => {
    //         Target target = new Target();
    //         target.RestoreFromToken(obj, true);
    //         GameObject tObj = Instantiate(prefab, obj.position, target.transform.rotation, target.transform.parent);
    //         //TODO
    //         // En skill info script para obtener el target info
    //         // instanciar skill info y setear el target como este actual
    //     });
    // }

//     public void SaveColorClicked()
// {
//     MainManager.Instance.SaveColor();
// }

// public void LoadColorClicked()
// {
//     MainManager.Instance.LoadColor();
//     ColorPicker.SelectColor(MainManager.Instance.TeamColor);
// }

}
