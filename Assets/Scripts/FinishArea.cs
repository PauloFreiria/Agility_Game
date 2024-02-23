using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishArea : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Timer.isTimerEnable = false;
        UIManager.Instance.ShowWinnerText();
        PlayerBehaviour.instance.DisableInput();
    }
}
