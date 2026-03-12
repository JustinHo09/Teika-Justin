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

    public void goToGame()
    {
        SceneManager.LoadScene("Teika-Justin");
    }
    
    public void goToMenu() {

		SceneManager.LoadScene("MainMenu");
}

    
}
