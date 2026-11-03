using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text gearText = null;
    [SerializeField]
    private TMP_Text snowPeepText = null;

    [SerializeField]
    private int totalGears = 0;
    [SerializeField]
    private int totalPeeps = 0;
    private static GameManagerScript instance = null;
    public static GameManagerScript Instance {  get { return instance; } }

    public int GetGearNumber()
    {
        return totalGears;
    }

    public int GetPeepNumber()
    {
        return totalPeeps;
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddGears(int gears)
    {
        totalGears += gears;
        Debug.Log("My Score: " + totalGears.ToString());
        UpdateScore();
        //Destroy(gameObject);
    }

    public void AddSnowies(int snowies)
    {
        totalPeeps += snowies;
        UpdateScore();
        //Destroy(gameObject);
    }

    private void UpdateScore()
    {
        gearText.text = "Gears: " + 0 + totalGears.ToString() + " / 4";
        snowPeepText.text = "Snowpeeps: " + 0 + totalPeeps.ToString() + " / 4";
    }

    // this function is for clicking the end game button
    public void ExitGame()
    {
        Application.Quit();
    }
}
