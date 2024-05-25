using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseStep : MonoBehaviour
{
    protected GameTutorial gameTutorial;
    public BoxCollider2D box;
    [SerializeField] protected Vector3 posHand;
    public virtual void OnEnable()
    {
        gameTutorial = GameTutorial.instance;
    }
    public virtual void StartStep()
    {
        gameObject.SetActive(true);
        gameTutorial.hand.SetPosHand(posHand);
    }
    public abstract void EndStep();
    protected virtual void OnMouseUp()
    {
        EndStep();
    }
}
