using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField]
    private string VictoryScreenName = null;
    private int presentPlayers = 0;

    public bool bothPlayersPresent()
    {
        return presentPlayers == 2;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ++presentPlayers;

        if (GameManagerScript.Instance.GetGearNumber() == 4 && GameManagerScript.Instance.GetPeepNumber() == 4
            && bothPlayersPresent())
        {
            SceneManager.LoadScene(VictoryScreenName);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        --presentPlayers;
    }
}
