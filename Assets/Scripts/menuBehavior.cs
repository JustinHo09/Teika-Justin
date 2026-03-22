using UnityEngine;
using UnityEngine.SceneManagement;
public class menuBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Goes from the current scene to the main game scene.
    public void goToGame()
    {
        SceneManager.LoadScene("Teika-Justin");
    }
    
    // Goes from the current scene to the menu scene.
    public void goToMenu() {

		SceneManager.LoadScene("MainMenu");
}

    
}
