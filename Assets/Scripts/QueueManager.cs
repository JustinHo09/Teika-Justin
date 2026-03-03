using UnityEngine;

public class QueueManager : MonoBehaviour
{
    public Sprite[] uis;

    public int[] queue;

    private int jokerPos;

    private int jokerCounter;

    private SpriteRenderer[] childRenderers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        jokerPos = GameObject.FindGameObjectWithTag("Player").GetComponent
            <PlayerBehavior>().fruits.Length-1;
        jokerCounter=0;
        queue = new int[7];
        for (int i = 0; i < 7; i++) {
            //Gives the valid objects for the preview
            queue[i] = Random.Range(0, 7);
            jokerCounter++;
        }

        childRenderers = new SpriteRenderer[4];
        for (int i = 0; i < transform.childCount; i++) {
            childRenderers[i] = transform.GetChild(i).GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (queue[i] == jokerPos) {
                childRenderers[i].sprite = uis[uis.Length-1];
            }else {
                childRenderers[i].sprite = uis[queue[i]];
            }
        }
    }

    public int updateQueue() {
        int currentType = queue[0];

        for (int i = 1; i < queue.Length; i++) {
            queue[i-1] = queue[i];
        }

        if ((Random.Range(0, 50) == 0) && jokerCounter >= 20) {
            queue[queue.Length - 1] = jokerPos;
            jokerCounter = 0;
        } else{
            queue[queue.Length - 1] = Random.Range(0, 7);
            jokerCounter++;
        }

        return currentType;
    }
}
