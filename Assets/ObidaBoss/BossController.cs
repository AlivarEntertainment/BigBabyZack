using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField]private List<GameObject> HorizHand = new List<GameObject>();
    //private GameObject[] HorizHand;
    
    [SerializeField]private List<GameObject> VertHand = new List<GameObject>();
    public bool CanAttackHor = false;
    public int HorPunches = 0;
    public int VerrPunches = 0;
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public int PhaseCounter;
    
    void Start()
    {
        StartCoroutine("StartBossCor");
        CanAttackHor = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(HorPunches <= 3 && CanAttackHor == true && HorPunches != 0)
        {
            if (timeBtwAttack <= 0.1f)
            {   
                timeBtwAttack = startTimeBtwAttack;
                AttackHor();
                
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
        else
        {
            CanAttackHor = false;
        }
        if(HorPunches == 4 && VerrPunches <= 3)
        {
            if (timeBtwAttack <= 0.1f)
            {   
                timeBtwAttack = startTimeBtwAttack;
                AttackVer();
                
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
        else if(HorPunches == 4 && VerrPunches >= 3)
        {
            StartCoroutine("ReloadBossCor");
        }
    }
    void AttackHor()
    {   
        int CurrentHand = Random.Range(0, HorizHand.Count);
        GameObject Hand = HorizHand[CurrentHand];
        Hand.SetActive(true);
        HorizHand.RemoveAt(CurrentHand);
        CanAttackHor = true;
        HorPunches += 1;
    }
    void AttackVer()
    {
        int CurrentHand = Random.Range(0, VertHand.Count);
        GameObject HandVert = VertHand[CurrentHand];
        HandVert.SetActive(true);
        VertHand.RemoveAt(CurrentHand);
        if(PhaseCounter >= 2)
        {
            int CurrentHand2 = Random.Range(0, VertHand.Count);
            GameObject HandVert2 = VertHand[CurrentHand2];
            HandVert.SetActive(true);
            VertHand.RemoveAt(CurrentHand2);
        }
        VerrPunches += 1;
    }
    void ReloadBoss()
    {
        VerrPunches = 0;
        HorPunches = 1;
        CanAttackHor = true;
        PhaseCounter += 1;
    }

    IEnumerator StartBossCor()
    {
        yield return new WaitForSeconds(4f);
        AttackHor();
    }
    IEnumerator ReloadBossCor()
    {
        HorPunches = 5;
        yield return new WaitForSeconds(6f);
        ReloadBoss();
    }
}
