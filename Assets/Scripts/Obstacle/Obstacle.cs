using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            Timer.isTimerEnable = false;
            UIManager.Instance.ShowLoserText();
            PlayerBehaviour.instance.DisableInput();
        }
    }
}
