using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
    }
}
