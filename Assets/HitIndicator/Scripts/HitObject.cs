using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HitObject : MonoBehaviour
{
    [SerializeField] [Range(0.01f,1)] private float showTime;
    [SerializeField] private AnimationCurve showTimeCurve;
    private RectTransform _rectTransform;
    private Image _image;
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponentInChildren<Image>();
    }
    public void Call(IndicateData indicateData) => StartCoroutine(Animate(indicateData));
    
    private IEnumerator Animate(IndicateData indicateData)
    {
        float time = 0;
        while (time < 1)
        {
            time += showTime * Time.deltaTime;
            _rectTransform.localEulerAngles = new Vector3(0, 0,  indicateData.Player.eulerAngles.y+indicateData.Angle);
            _image.color = Color.Lerp(indicateData.Color, Color.clear, showTimeCurve.Evaluate(time));
            yield return null;
        }
    }
}
