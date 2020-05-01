using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class updateHPValue : MonoBehaviour
{
    TMP_Text HP;
    private EnemyRxDamage enemyHP;
    public GameObject enemyObj;

    // Start is called before the first frame update
    void Start()
    {
        HP = GetComponentInChildren<TMP_Text>();
        enemyHP = enemyObj.GetComponentInChildren<EnemyRxDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = enemyHP.health.ToString();
    }
}
