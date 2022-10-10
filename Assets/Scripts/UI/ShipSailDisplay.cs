using UnityEngine;
using TMPro;

public class ShipSailDisplay : MonoBehaviour
{
    public ShipMovement shipMovement;

    private TMP_Text element;
    
    void Start()
    {
        element = GetComponent<TMP_Text>();
    }

    void Update()
    {
        string sailPosition = shipMovement.sailPosition.ToString();

        element.text = string.Format("{0} Sail", sailPosition);
    }
}
