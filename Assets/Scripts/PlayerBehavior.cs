using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerBehavior : MonoBehaviour
{
    // cherry, strawberry, grape, lemon, orange, apple, banna, pear, pineapple, watermelon
    // we need to check if two fruits are touching, then we need to check if they are the same fruit
    // we need to then remove the two touching fruit and replace it with the next fruit is if any
    // use randgom generator and if it is in a range give us x fruit or y fruit
    // give bigger fruit or make melon the largest and un-mergable
    public float speed;
    private GameObject currentFruit;

    public GameObject[] fruits;

    private float startTime = 0.0f;
    public float min;
    public float max;
    public float offY = -0.6f;

    public AudioSource dropping;
    
    public int[] points;
    public int totalScore;
    public GameObject scoreBoard;

    public TMP_Text textField;
    //public int move;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        startTime = 0.0f;
        totalScore = 0;
        textField.SetText("Score: " + totalScore);
        //move =0;//0 means you can move in either direction
    }

    // Update is called once per frame
    void Update() {
    float offset= 0.0f;
        
        //Gets the fruit for the player
        if (currentFruit != null) {
            
            //current player position
            Vector3 playerPos = transform.position;
            Vector3 fruitOffset = new Vector3(0.0f,offY,0.0f);
            currentFruit.transform.position = playerPos + fruitOffset;
        }
        else {
            int choice = Random.Range(0, fruits.Length);
            
            currentFruit = Instantiate(fruits[choice],new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
        }

        // Drops the fruit
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Rigidbody2D body = currentFruit.GetComponent<Rigidbody2D>();
            body.gravityScale = 1.0f;
            
            Collider2D collider = currentFruit.GetComponent<Collider2D>();
            collider.enabled = true;
            
            currentFruit = null;
        }
        
        // Moves the player left or right
        bool left = (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed);
                    //&& move != 1;
        if (left == true) {
            offset = -speed;

        }

        bool right = (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed);
                     //&& move != 2;
        if (right == true) {
            offset = speed;
        }

        Vector3 newPos = transform.position;
        newPos.x = newPos.x + offset;
        //prevents movement too far right;
        if (newPos.x > max) {
            newPos.x = max;
            
        }
        //prevents movement too far left;
        if (newPos.x < min) {
            newPos.x = min;
            
        }

        transform.position = newPos;

    }

    public void updateScore(int index) {
        totalScore = totalScore + points[index];
        textField.SetText("Score: " + totalScore);
    }
    
    // private void onCollisionEnter2d(Collision2D other){
    //     if (other.gameObject.CompareTag("LB")) {
    //         move = 1; // Cannot move left
    //     } else if (other.gameObject.CompareTag("RB")) {
    //         move = 2;
    //     }
    // }
    //
    // private void onCollisionStay2d(Collision2D other){
    //     //if (other.gameObject){
    //         
    //     //}
    // }
    
    // private void onCollisionExit2d(Collision2D other){
    //     if (other.gameObject.CompareTag("LB") || other.gameObject.CompareTag("RB")) {
    //         move = 0; // can move left and right
    //     }
    // }
    
}
