using UnityEngine;

public class MenuAnim : MonoBehaviour
{
    public Animator menuAnimator;

    void Start()
    {
        //GameObject menuObject = GameObject.FindWithTag("MenuBackground");
        //menuAnimator = menuObject.GetComponent<Animator>();

        menuAnimator.Rebind();
        menuAnimator.Update(0f);

        menuAnimator.SetTrigger("MenuAnim");
    }
}
