using UnityEngine;

public class Flock : MonoBehaviour {

    // Access the FlockManager script
    public FlockManager myManager;
    // Prefab initial speed;
    float speed;
    // Bool used to check the limits
    bool turning = false;

    void Start() {

        // Assign a random speed to each this prefab
        speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);
    }

    // Update is called once per frame
    void Update() {

        // Determine the bounding box of the manager cube
        Bounds b = new Bounds(myManager.transform.position, myManager.movingLimits * 2.0f);

        // If the object is outside the bounds of the cube or about to hit something
        // then start turning around
        RaycastHit hit = new RaycastHit();
        Vector3 direction = Vector3.zero;

        if (!b.Contains(transform.position)) {

            turning = true;
            direction = myManager.transform.position - transform.position;
        } else if (Physics.Raycast(transform.position, this.transform.forward * 50.0f, out hit)) {

            turning = true;
            // Debug.DrawRay(this.transform.position, this.transform.forward * 50.0f, Color.red);
            direction = Vector3.Reflect(this.transform.forward, hit.normal);
        } else {

            turning = false;
        }

        // Test if we're turning
        if (turning) {

            // Turn towards the centre of the cube
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(direction),
                                                  myManager.rotationSpeed * Time.deltaTime);
        } else {

            // 10% chance of altering prefab speed
            if (Random.Range(0.0f, 100.0f) < 10.0f) {

                speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);
            }
        }

        transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);
    }


}
