using System;
using UnityEngine;

public class Food : InteractablePickup {

    public FoodSO m_FoodData;
    private MeshRenderer m_Renderer;
    private Collider m_Collider;
    public static Action<Food> OnFoodPick;

    public void Awake() {
        m_Renderer = GetComponent<MeshRenderer>();
        m_Collider = GetComponent<Collider>();
    }

    public override void Interact(InteractionController interactingActor) {
        base.Interact(interactingActor);
        OnFoodPick?.Invoke(this);
    }

    public override void Use() {
        // WE CAN CALL THE DROP FUNCTION FROM BASE CALL WHICH WILL SET THE CURRENT ITEM TO NULL AND UNPARENT IT FROM THE PLAYER
        base.Drop();
        m_Renderer.enabled = false;
        m_Collider.enabled = false;
    }
}