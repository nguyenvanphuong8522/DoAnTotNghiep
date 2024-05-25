using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTutorial : Singleton<GameTutorial>
{
    public DataTutorial data;
    [SerializeField] private List<BaseStep> steps;
    public DialogTalk dialogTalk;
    private int indexStep = 0;
    public Hand hand;
    public GameObject tower;
    public Obstacle obstacle;
    public ButtonEffectLogic btnEnd;
    protected override void Awake()
    { 
        base.Awake();
        gameObject.SetActive(false);
    }
    public void StartTutorial()
    {
        gameObject.SetActive(true);
        steps[indexStep].StartStep();
        UpdateTextTalk();
    }
    public void NextStep()
    {
        steps[++indexStep].StartStep();
        UpdateTextTalk();
    }
    [Button]
    public void Speed()
    {
        Time.timeScale = 3;
    }
    public void UpdateTextTalk()
    {
        dialogTalk.SetText(data.texts[indexStep]);
    }
}
