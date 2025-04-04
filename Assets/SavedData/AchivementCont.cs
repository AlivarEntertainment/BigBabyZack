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
            Debug.Log(LevelRiched);
           if(PreviousCard.activeSelf == false)
           {     
                this.gameObject.SetActive(false);
                
           }
           if(LevelRiched < LevelToReach && PreviousCard.activeSelf == true)
           {
                ThisCard.sprite = CardGrey;
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
            else if(ThisNatan -1 == Natan && PreviousCard.activeSelf== true)
            {
                ThisCard.sprite = CardGrey;
            }
        }
    }
}
