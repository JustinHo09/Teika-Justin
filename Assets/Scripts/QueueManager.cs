using UnityEngine;

public class QueueManager : MonoBehaviour
{
    public Sprite[] uis;

    public int[] queue;

    private int jokerPos;

    private int jokerCounter;
    
    public int maxFruit;

    private SpriteRenderer[] childRenderers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        // get the joker's position from the fruit array
        jokerPos = GameObject.FindGameObjectWithTag("Player").GetComponent
            <PlayerBehavior>().fruits.Length-1;
        jokerCounter=0;
        // make a queue of length 7
        queue = new int[7];
        // give valid indexes for the queue array
        // also update joker counter, which is used to keep track of how many
        // fruits have been created since the last joker
        for (int i = 0; i < 7; i++) {
            //Gives the valid objects for the preview
            queue[i] = Random.Range(0, maxFruit+1);
            jokerCounter++;
        }

        // make the children the sprite for the corresponding fruit in the queue
        childRenderers = new SpriteRenderer[4];
        for (int i = 0; i < transform.childCount; i++) {
            childRenderers[i] = transform.GetChild(i).GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update() {
        // update the children sprite to match the one represented by the index in the queue
        for (int i = 0; i < transform.childCount; i++)
        {
            // make it a joker or fruit
            if (queue[i] == jokerPos) {
                childRenderers[i].sprite = uis[uis.Length-1];
            }else {
                childRenderers[i].sprite = uis[queue[i]];
            }
        }
    }

    public int updateQueue() {
        int currentType = queue[0];

        // move everything down one
        for (int i = 1; i < queue.Length; i++) {
            queue[i-1] = queue[i];
        }

        // make a random number to see if a joker will be created
        // It makes a joker a 1 in 50 chance, while also having a 20 fruit cooldown
        if ((Random.Range(0, 50) == 0) && jokerCounter >= 20) {
            queue[queue.Length - 1] = jokerPos;
            jokerCounter = 0;
            // Joker is not created and just make it a fruit
        } else{
            queue[queue.Length - 1] = Random.Range(0, maxFruit+1);
            jokerCounter++;
        }

        return currentType;
    }
}
