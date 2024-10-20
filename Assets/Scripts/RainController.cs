using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NewBehaviourScript : MonoBehaviour
{

    public Transform houseTransform;
    public Transform playerTransform;
    public Light lightlight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 housePosition = new Vector2(houseTransform.position.x, houseTransform.position.z);
        Vector2 playerPosition = new Vector2(playerTransform.position.x, playerTransform.position.z);
        float distanceToHouse = Vector2.Distance(housePosition, playerPosition);
        var emission = GetComponent<ParticleSystem>().emission;
        //Debug.Log(distanceToHouse);
        //Debug.Log(GetComponent<ParticleSystem>().emission.rateOverTime.constant);
        if (distanceToHouse > 55)
        {
            emission.rateOverTime = 0;
            lightlight.intensity = 1;

        }
        else if (distanceToHouse > 15)
        {
            emission.rateOverTime = (int)(1900 * (1 - (distanceToHouse - 15) / 40.0));
            lightlight.intensity = (distanceToHouse - 15) / 40f;
        }
        else 
        {
            emission.rateOverTime = 1900;
            lightlight.intensity = 0;
        }
        
    }
}
