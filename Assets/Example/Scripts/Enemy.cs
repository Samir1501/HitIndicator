using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        HitIndicator indicator = other.transform.GetComponent<HitIndicator>();
        indicator.Damage(10,transform.position);
    }
}
