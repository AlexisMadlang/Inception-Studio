using UnityEngine;

/// <summary>
/// Spin an object at a constant speed.
/// </summary>
public class Spinner : MonoBehaviour
{
    
    [SerializeField]
    float speed = 5f;   // User-defined speed

    // Start is called before the first frame update
    void Start()
    {
        /* Make the object start at a random orientation. */
        float angle = Random.Range(-180f, 180f);

        // Your code here
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        /* Spin the object at a constant speed. */

        // Your code here
        transform.Rotate(Vector3.up, speed * Time.deltaTime);

    }
}
