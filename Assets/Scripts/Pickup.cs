using UnityEngine;

public class Pickup : MonoBehaviour
{
    const string PLAYER_TAG = "Player";


    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            Debug.Log(other.gameObject.name);
        }
    

    
    }
}  
