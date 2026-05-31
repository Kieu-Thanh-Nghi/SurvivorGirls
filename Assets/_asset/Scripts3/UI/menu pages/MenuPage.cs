using UnityEngine;

public class MenuPage : AbstractState
{
    [SerializeField] GameObject enableMark;
    [SerializeField] GameObject ownedCanvas;

    public override void Enter()
    {
        Debug.Log("PageChange: enter");
        Debug.Log("PageChange:" + transform.parent.gameObject.name);
        Debug.Log("PageChange: enableMark null:" + (enableMark == null));
        enableMark.SetActive(true);
        Debug.Log("PageChange: ownedCanvas null:" + (ownedCanvas == null));
        if (ownedCanvas != null) ownedCanvas?.SetActive(true);
    }

    public override void Exit()
    {
        Debug.Log("PageChange: exit");
        Debug.Log("PageChange:" + transform.parent.gameObject.name);
        Debug.Log("PageChange: enableMark null:" + (enableMark == null));
        enableMark.SetActive(false);
        Debug.Log("PageChange: ownedCanvas null:" + (ownedCanvas == null));
        if(ownedCanvas != null) ownedCanvas?.SetActive(false);
    }
}