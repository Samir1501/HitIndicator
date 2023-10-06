using System.Collections.Generic;
using UnityEngine;

public class HitIndicatorUI : MonoBehaviour
{
    private static HitIndicatorUI _instance;
    public static HitIndicatorUI Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<HitIndicatorUI>();
            return _instance;
        }
    }
    [SerializeField] private int hitObjectCount;
    [SerializeField] private HitObject hitObjectPrefab;
    private RectTransform _container;
    private readonly Queue<HitObject> _hitObjects = new ();

    private void Awake()
    {
        _container = GetComponent<RectTransform>();
        CreateHitObjects();
    }
    private void CreateHitObjects()
    {
        for (int i = 0; i < hitObjectCount; i++)
            _hitObjects.Enqueue(Instantiate(hitObjectPrefab, _container));
    }
    public void Indicate(IndicateData indicateData)
    {
        HitObject hitObject = _hitObjects.Dequeue();
        hitObject.Call(indicateData);
        _hitObjects.Enqueue(hitObject);
    }
}
