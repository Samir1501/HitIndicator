using System;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] [Range(0.1f,10)]private float time;
    private ParticleSystem _effect;
    private void Awake() => _effect = GetComponentInChildren<ParticleSystem>();
    private void Start() => StartCoroutine(Fıre());
    private IEnumerator Fıre()
    {
        while (true) {
            _effect.Play();
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 100)) {
                if (hit.transform.TryGetComponent(typeof(HitIndicator), out Component indicator)) {
                    HitIndicator ict = indicator as HitIndicator;
                    if (ict != null) ict.Damage(10*time,hit.point);
                }
            }
            yield return new WaitForSeconds(time);
        }
        // ReSharper disable once IteratorNeverReturns
    }
}
