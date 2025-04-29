using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    const string PLAYER_TAG = "Player";



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            OnPickup();
            Destroy(this.gameObject);
        }
    }

    protected abstract void OnPickup();
}
