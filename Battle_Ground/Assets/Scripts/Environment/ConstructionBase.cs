using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConstructionBase : MonoBehaviour {

    [SerializeField]
    private TextMeshPro TimerTxt;

    public float constructionTime;
    [HideInInspector]
    public bool bIsTouchable;
    private bool bIsBuildingPlaced;
    private string mTimeStr;
    private float StartTime, CurrentTime;
    void OnEnable()
    {
        bIsTouchable = (constructionTime > 0) ? false : true;
    }

    public bool IsConstructed()
    {
        return bIsTouchable;
    }

    public void SetIsBuildingPlaced()
    {
        bIsBuildingPlaced = true;
        StartTime = CurrentTime = Time.time;
        StartCoroutine("EnableTimer");
    }

    private IEnumerator EnableTimer()
    {
        int InHrs = 0, InMins = 0, InSecs = 0;
        while (!bIsTouchable && bIsBuildingPlaced)
        {
            constructionTime -= 1;
            InHrs = (int)(constructionTime / 3600);
            InMins = (int)((constructionTime / 60) % 60);
            InSecs = (int)(constructionTime % 60);
            mTimeStr = string.Format("{0:00}: {1:00}: {2:00}", InHrs, InMins, InSecs);
            bIsTouchable = (constructionTime <= 0) ? true : false;
            TimerTxt.SetText(bIsTouchable ? string.Empty : mTimeStr);
            yield return new WaitForSeconds(1);
        }
    }
}
