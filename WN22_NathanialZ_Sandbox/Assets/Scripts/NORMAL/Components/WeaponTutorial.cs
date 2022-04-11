using UnityEngine;
using Normal.Realtime;

//Put this script on gate
public class WeaponTutorial : RealtimeComponent<TutorialModel>
{
    [SerializeField] GameObject gate;
    [SerializeField] int hitCountToPass;
    public void TutorialHit()
    {
        model.tutorialHit++;
    }

    protected override void OnRealtimeModelReplaced(TutorialModel previousModel, TutorialModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.tutorialHitDidChange -= AddToHitCount;
        }
        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                model.tutorialHit = 0;
            }
            currentModel.tutorialHitDidChange += AddToHitCount;
        }
    }

    private void AddToHitCount(TutorialModel model, int value)
    {
        if (model.tutorialHit == hitCountToPass)
        {
            gate.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
