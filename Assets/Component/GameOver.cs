using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Text roundsText;


    //public void Retry()
    //{
    //    sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    //}

    //public void Menu()
    //{
    //    sceneFader.FadeTo(menuSceneName);
    //}

    void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Go to menu");
    }

}