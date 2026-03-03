using UnityEditor;
using UnityEngine;
using TMPro;

public class ResetGame : MonoBehaviour
{
    private GameObject[] onScreenFruits;

    private GameObject[] jokers;
    
    private int highestScore;

    public GameObject player;
    
    public TMP_Text highScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highestScore=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetAll()
    {
        onScreenFruits = GameObject.FindGameObjectsWithTag("Fruit");
        jokers = GameObject.FindGameObjectsWithTag("Joker");

        for (int i = 0; i < jokers.Length; i++)
        {
            Destroy(jokers[i]);
        }

        for (int i = 0; i < onScreenFruits.Length; i++)
        {
            Destroy(onScreenFruits[i]);
        }

        int newScore = player.GetComponent<PlayerBehavior>().totalScore;
        
        if (newScore > highestScore) {
            highScore.SetText("High Score: " + newScore);
            highestScore = newScore;
        }
        
        player.GetComponent<PlayerBehavior>().enabled = true;
        player.GetComponent<PlayerBehavior>().totalScore = 0;
        player.GetComponent<PlayerBehavior>().textField.SetText("Score: " + 0);
        GameObject.FindGameObjectWithTag("GameOver").SetActive(false);
    }
}
