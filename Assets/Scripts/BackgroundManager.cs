using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject backgroundPrefab;
    
    public float speed;

    private GameObject[] backgrounds;

    public float pivotPoint;

    public float scale;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backgroundPrefab.transform.localScale = new Vector3(scale, scale, scale);
        pivotPoint = scale * 16 * -0.32f;
        
        backgrounds = new GameObject[3];

        
        for (int i = 0; i < 3; i++)
        {
            float xPos = pivotPoint - (pivotPoint / 2 * i);
            float yPos = pivotPoint - (pivotPoint / 2 * i);
            Vector3 pos = new Vector3(xPos, yPos,0.0f);
            backgrounds[i] = Instantiate(backgroundPrefab, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++) {
            float xPos = backgrounds[i].transform.position.x + speed * Time.deltaTime;
            float yPos = backgrounds[i].transform.position.y + speed * Time.deltaTime;
            Vector3 pos = new Vector3(xPos, yPos, 0.0f);
            backgrounds[i].transform.position = pos;
            if (xPos > -1 * (pivotPoint / 2))
            {
                Vector3 pivot = new Vector3(pivotPoint, pivotPoint,0.0f);
                backgrounds[i].transform.position = pivot;
            }
        }
    }
}
