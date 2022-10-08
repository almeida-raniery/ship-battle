using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFireInput : MonoBehaviour
{
    public string frontCannonButton;
    public UnityEvent frontCannonEvent;
     public string leftCannonButton;
    public UnityEvent leftCannonEvent;
    public string rightCannonButton;
    public UnityEvent rightCannonEvent;
    
    void Update()
    {
        if (Input.GetButtonDown(frontCannonButton)) 
            frontCannonEvent.Invoke();
        if (Input.GetButtonDown(leftCannonButton)) 
            leftCannonEvent.Invoke();
        if (Input.GetButtonDown(rightCannonButton)) 
            rightCannonEvent.Invoke();
    }
}
