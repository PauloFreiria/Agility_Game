using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartArea : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        
        Timer.isTimerEnable = true;
        
    }
}
