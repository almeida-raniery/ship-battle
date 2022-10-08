using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public ShipHealth target;

    private float fillStep;
    private Image element;

    // Start is called before the first frame update
    void Start()
    {
        fillStep = 1f/target.maxHealth;
        element  = GetComponent<Image>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        float fillPercent = fillStep * target.health;
        
        element.fillAmount         = fillPercent;

        if (fillPercent < 0.75f)
            element.color = Color.yellow;
        if (fillPercent < 0.5f)
            element.color = Color.red;
    }
}
