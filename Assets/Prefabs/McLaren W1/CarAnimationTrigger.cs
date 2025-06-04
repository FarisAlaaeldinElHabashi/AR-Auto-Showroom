using UnityEngine;

public class CarAnimationTrigger : MonoBehaviour
{
    public Animator carAnimator;

    public void PlayAnimation()
    {
        carAnimator.SetTrigger("Play"); // must match the Trigger name exactly
    }
}
