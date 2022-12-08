using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Dialog dialogGameOver;
    public Text txtSkills;
    public Text txtStars;
    public byte nSkills;
    public byte nStars;
    public bool isGameStart;

    void Start()
    {
        dialogGameOver = GameObject.Find("Dialog GameOver").GetComponent<Dialog>();
        nSkills = 0;
        nStars = 0;
        txtSkills.text = "0/14";
        txtStars.text = "0/14";
    }

    public void StarEarned(byte idx)
    {
        nStars++;
        txtStars.text = nStars + "/14";
    }

    public void SkillEarned(byte idx)
    {
        nSkills++;
        txtSkills.text = nSkills + "/14";
    }
    
    public void GameOver()
    {
        dialogGameOver.OpenDialog();
        // restartButton.gameObject.setActive(true);
    }

    public void Finished()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);//reiniciar actual
        SceneManager.LoadScene((int)Screens.Greeting); //cargar pantalla de saludos
    }
}
