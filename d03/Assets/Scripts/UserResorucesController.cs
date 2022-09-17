using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserResorucesController : MonoBehaviour
{
    public gameManager manager;
    [SerializeField] private TMP_Text energyField;
    [SerializeField] private TMP_Text healthPointsField;
    
    void Update()
    {
        energyField.text = manager.playerEnergy.ToString();
        healthPointsField.text = manager.playerHp.ToString();
    }
}
