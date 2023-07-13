using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionGuideHandler : MonoBehaviour
{
    private void Start() {
        missionText.text = missions[0];
    }

    [SerializeField]
    private string[] missions;

    private int currentMissionID = 0;

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
}
