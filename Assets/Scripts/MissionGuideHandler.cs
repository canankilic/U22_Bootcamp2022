using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionGuideHandler : MonoBehaviour
{
     public int currentMissionID = 0;
     
    private void Start() {
        missionText.text = missions[currentMissionID];
    }

    [SerializeField]
    private string[] missions;

   

    [SerializeField]
    private TextMeshProUGUI missionText;

    public void UpdateMissionToNext()
    {
        currentMissionID++;
        if (missions[currentMissionID]!=null)
        {
            missionText.text = missions[currentMissionID];
        }
    }

    public void SetMission(int order){
        currentMissionID = order;
        missionText.text = missions[currentMissionID];
    }
}
