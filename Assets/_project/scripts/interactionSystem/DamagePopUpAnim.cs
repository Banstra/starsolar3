using TMPro;
using UnityEngine;

public class DamagePopUpAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public AnimationCurve opacityCurve;
    private TextMeshProUGUI tmp;
    private float time = 0;
    public AnimationCurve scaleCurve;

    private void Awake()
    {
        tmp = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void Update()
    {
        tmp.color = new Color(1, 1, 1, opacityCurve.Evaluate(time));
        transform.localScale = Vector3.one * scaleCurve.Evaluate(time);
        time += Time.deltaTime;
    }
}
