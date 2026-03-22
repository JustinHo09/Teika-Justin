using UnityEngine;

public class BorderBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public float timeOut;
    public float timeStart;

    public GameObject gameOver;
    
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // if a fruit touches the border start a timer
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Fruit")) {
            timeStart = Time.time;
        }
    }
    
        // if they tough longer than the time out time, then end make the
        // game over message appear.
        private void OnTriggerStay2D(Collider2D other) {
            if (other.gameObject.CompareTag("Fruit")) {
                float current = Time.time;
                float timeThusFar = current - timeStart;
                if ( timeThusFar > timeOut){ 
                    gameOver.SetActive(true);
                }
            }
        }
    
        private void OnTriggerExit2D(Collider2D other) {
            if (other.gameObject.CompareTag("Fruit")) {
                
            }
        }
}
