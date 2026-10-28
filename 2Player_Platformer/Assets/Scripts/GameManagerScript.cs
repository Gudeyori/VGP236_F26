using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText = null; 
    private int totalPoints = 0;
    private static GameManagerScript instance = null;
    public static GameManagerScript Instance {  get { return instance; } }
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
    public void AddPoints(int points)
    {
        totalPoints += points;
        Debug.Log("My Score: " + totalPoints.ToString());
        UpdateScore();
        Destroy(gameObject);
    }

    private void UpdateScore()
    {
        //scoreText.text = "Gears Collected: " + totalPoints.ToString() + " / 4";
    }
}
