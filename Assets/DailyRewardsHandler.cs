using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardsHandler : MonoBehaviour
{
    public Text rewardText;
    int rewardValue;
    // Start is called before the first frame update
    void Start()
    {
        GleyDailyRewards.Calendar.AddClickListener(CalendarButtonClicked);
    }

    private void CalendarButtonClicked(int dayNumb, int rewardValue, Sprite rewardSprite)
    {
        this.rewardValue += rewardValue;
        rewardText.text = rewardValue.ToString();
    }

    public void ShowCalendar()
    {
        GleyDailyRewards.Calendar.Show();
    }
}
