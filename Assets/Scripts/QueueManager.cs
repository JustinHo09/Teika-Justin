using UnityEngine;

public class QueueManager : MonoBehaviour
{
    public Sprite[] uis;

    public int[] queue;

    private SpriteRenderer[] childRenderers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        queue = new int[7];
        for (int i = 0; i < 7; i++) {
            //Gives the valid objects for the preview
            queue[i] = Random.Range(0, 7);
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
            childRenderers[i].sprite = uis[queue[i]];
        }
    }

    public int updateQueue() {
        int currentType = queue[0];

        for (int i = 1; i < queue.Length; i++) {
            queue[i-1] = queue[i];
        }

        queue[queue.Length - 1] = Random.Range(0, 7);
        
        return currentType;
    }
}
