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
        // Get all fruits and joker's on the game scene
        onScreenFruits = GameObject.FindGameObjectsWithTag("Fruit");
        jokers = GameObject.FindGameObjectsWithTag("Joker");

        // Loop to destory all jokers
        for (int i = 0; i < jokers.Length; i++)
        {
            Destroy(jokers[i]);
        }

        // Loop to destory all fruits
        for (int i = 0; i < onScreenFruits.Length; i++)
        {
            Destroy(onScreenFruits[i]);
        }

        // Get the player's current score
        int newScore = player.GetComponent<PlayerBehavior>().totalScore;
        
        // Update high score if current is higher
        if (newScore > highestScore) {
            highScore.SetText("High Score: " + newScore);
            highestScore = newScore;
        }
        // re-enable the player script, reset current score to 0
        player.GetComponent<PlayerBehavior>().enabled = true;
        player.GetComponent<PlayerBehavior>().totalScore = 0;
        player.GetComponent<PlayerBehavior>().textField.SetText("SCORE: " + 0);
        
        // reset combo and board
        player.GetComponent<PlayerBehavior>().combos = 0;
        player.GetComponent<PlayerBehavior>().currentCombo.SetText("COMBO: " + 0);

        // Turn off the game over screen.
        GameObject.FindGameObjectWithTag("GameOver").SetActive(false);
    }
}
