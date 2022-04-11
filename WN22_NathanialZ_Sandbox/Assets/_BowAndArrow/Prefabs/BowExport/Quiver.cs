using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Normal.Realtime;

public class Quiver : XRBaseInteractable
{
    public GameObject arrowPrefab = null;
    [SerializeField] Realtime _realtime;

    protected override void OnEnable()
    {
        base.OnEnable();
        selectEntered.AddListener(CreateAndSelectArrow);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        selectEntered.RemoveListener(CreateAndSelectArrow);
    }

    private void CreateAndSelectArrow(SelectEnterEventArgs args)
    {
        // Create arrow, force into interacting hand
        Arrow arrow = CreateArrow(args.interactor.transform);
        interactionManager.ForceSelect(args.interactor, arrow);
    }

    private Arrow CreateArrow(Transform orientation)
    {
        // //Create arrow, and get arrow component
        //GameObject arrowObject = Instantiate(arrowPrefab, orientation.position, orientation.rotation);
        //return arrowObject.GetComponent<Arrow>();
        var options = new Realtime.InstantiateOptions()
        {
            ownedByClient = true,
            preventOwnershipTakeover = false,
            useInstance = _realtime
        };
        GameObject row = Realtime.Instantiate(arrowPrefab.name, orientation.position, orientation.rotation, options);
        return row.GetComponent<Arrow>();
    }
}
