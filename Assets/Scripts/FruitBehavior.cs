using UnityEngine;

public class FruitBehavior : MonoBehaviour
{
	public GameObject[] fruits;
	public int fruitType;


	// Fruit point order: 2,4,8,16,32,64,128,256,512
    //public float timeOut;
    //public float timeStart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        fruits = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().fruits;
    }

    // Update is called once per frame
    void Update() {
        
    }


	private void OnCollisionEnter2D (Collision2D other){
		if(other.gameObject.CompareTag("Fruit")) {
			int otherType = other.gameObject.GetComponent<FruitBehavior>().fruitType;
			if(otherType == fruitType && fruitType < fruits.Length-1) {

				if (gameObject.transform.position.y < other.transform.position.y ||
				    (gameObject.transform.position.y == other.transform.position.y &&
				     gameObject.transform.position.x < other.transform.position.x)) {

					//GetComponent<AudioSource>().Play();

					// create the fruit
					int choice = fruitType + 1;
					GameObject currentFruit = Instantiate(fruits[choice], Vector3.Lerp(
							gameObject.transform.position, other.gameObject.transform.position, 0.5f),
						Quaternion.identity);
					currentFruit.GetComponent<Collider2D>().enabled = true;
					currentFruit.GetComponent<Rigidbody2D>().gravityScale = 1.0f;

					GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().updateScore(fruitType);

					//Destroy both fruits
					Destroy(other.gameObject);
					Destroy(gameObject);
				}

			}
		}
	}

    // private void OnTriggerEnter2D(Collider2D other) {
    //     if (other.gameObject.CompareTag("TopBorder")) {
    //         timeStart = Time.time;
    //     }
    //     
    // }
    //
    // private void OnTriggerStay2D(Collider2D other) {
    //     if (other.gameObject.CompareTag("TopBorder")) {
    //         float current = Time.time;
    //         float timeThusFar = current - timeStart;
    //         if ( timeThusFar > timeOut) { 
    //             
    //         }
    //     }
    //     
    // }
    //
    // private void OnTriggerExit2D(Collider2D other) {
    //     if (other.gameObject.CompareTag("TopBorder")) {
    //         timeStart = 0.0f;
    //     }
    // }
    
}
