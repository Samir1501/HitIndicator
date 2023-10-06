using UnityEngine;

public struct IndicateData
{
    public Transform Player;
    public float Angle;
    public Color Color;
}

public class HitIndicator : MonoBehaviour
{
    private HitIndicatorUI _hitIndicatorUI;
    private IndicateData _indicateData;
    [SerializeField] private Gradient damageColorGradient; 
    private void Awake() => _hitIndicatorUI = HitIndicatorUI.Instance;
    public void Damage(float damage, Vector3 position = default)
    {
        Vector3 playerPosition = transform.position;
        playerPosition.y = position.y = 0;
        _indicateData.Color = damageColorGradient.Evaluate(damage / 100);
        _indicateData.Angle = Vector3.SignedAngle(Vector3.forward, position - playerPosition,Vector3.down);
        _indicateData.Player = transform;
        _hitIndicatorUI.Indicate(_indicateData);
    }
}
