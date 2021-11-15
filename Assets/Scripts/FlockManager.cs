using UnityEngine;

public class FlockManager : MonoBehaviour {

    // Access the object prefab
    public GameObject Prefab;
    public string ObjectTag;
    
    // Number of objects that are going to be instantiated
    public int numObjectsOfFlock = 20;
    // Array of prefabs
    public GameObject[] allObjectsInFlock;
    // Flying bounds
    public Vector3 movingLimits = new Vector3(5.0f, 5.0f, 5.0f);
    // Goal position
    public Vector3 goalPos;


    [Header("Object Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;          // Minimum speed range
    [Range(0.0f, 5.0f)]
    public float maxSpeed;          // Maximum speed range
    [Range(1.0f, 10.0f)]
    public float neighbourDistance; // Prefab neighbout distance
    [Range(0.0f, 5.0f)]
    public float rotationSpeed;     // Speed at which the prefabs rotate

    void Start() {

        // Allocate the allObjectsInFlock array
        allObjectsInFlock = new GameObject[numObjectsOfFlock];
        // Loop throught the array instantiating the prefabs.
        for (int i = 0; i < numObjectsOfFlock; ++i) {


            allObjectsInFlock[i] = InstantiateObject();
            allObjectsInFlock[i].GetComponent<Flock>().myManager = this;
        }

        // Target for the prefbas to head for
        goalPos = this.transform.position;

        //Instantiates a new gameobject in seconds
        //InvokeRepeating("InstantiateObject", 20f, 20f);
    }

    // Update is called once per frame
    void Update() {

        // Update the target for the prefabs to head for with a random chance
        if (Random.Range(0.0f, 100.0f) < 10.0f) {
            goalPos = this.transform.position + new Vector3(Random.Range(-movingLimits.x, movingLimits.x),
                                                            Random.Range(-movingLimits.x, movingLimits.x),
                                                            Random.Range(-movingLimits.x, movingLimits.x));
        }
    }

    GameObject InstantiateObject()
    {
        Vector3 pos = this.transform.position + new Vector3(Random.Range(-movingLimits.x, movingLimits.x),
                                                    Random.Range(-movingLimits.x, movingLimits.x),
                                                    Random.Range(-movingLimits.x, movingLimits.x));

        return (GameObject)Instantiate(Prefab, pos, Quaternion.identity);
    }

    public void ResortArray()
    {
        allObjectsInFlock = GameObject.FindGameObjectsWithTag(ObjectTag);
    }
}
