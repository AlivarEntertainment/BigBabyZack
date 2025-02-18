using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementCont : MonoBehaviour
{
    public enum AchiveType{
        LevelReach,
        DoSmth,
        NatanDia
    }
    public AchiveType achiveType;
    private int LevelRiched;
    private int AchiveDone;
    private int Natan;
    [Header("MegaSystem")]
    public GameObject PreviousCard;
    public SpriteRenderer ThisCard;
    public Sprite CardGrey;

    [Header("CurrentValues")]
    public int LevelToReach;
    public int QuestNumber;
    public int ThisNatan;
    public void FixedUpdate()
    {
        if(achiveType == AchiveType.LevelReach)
        {
            LevelRiched = PlayerPrefs.GetInt("LevelReached");
            
           
           if(LevelRiched <= LevelToReach)
           {     
            Debug.Log("lvl");
                if(PreviousCard.active == false)
                {   
                    Debug.Log("NotActive");
                    this.gameObject.SetActive(false);
                }
                else
                {
                    ThisCard.sprite = CardGrey;
                }
           }
           
        }
        if(achiveType == AchiveType.DoSmth)
        {
           AchiveDone = PlayerPrefs.GetInt("DoQuest");
           if(AchiveDone < QuestNumber)
           {
                this.gameObject.SetActive(false);
           }
        }
        if(achiveType == AchiveType.NatanDia)
        {
            Natan = PlayerPrefs.GetInt("Natan");
            
            if(ThisNatan > Natan)
            {
                this.gameObject.SetActive(false);
            }
            else if(ThisNatan -1 == Natan && PreviousCard.active == true)
            {
                ThisCard.sprite = CardGrey;
            }
        }
    }
}
