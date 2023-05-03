using UnityEngine;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private UIDocument _mainMenu;
    [SerializeField]
    private UIDocument _levelsMenu;

    public static MenuManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void TurnOffAllScreens()
    {
        SetDisplayState(_mainMenu, DisplayStyle.None);
        SetDisplayState(_levelsMenu, DisplayStyle.None);
    }

    public void TurnMenuOn()
    {
        TurnOffAllScreens();
        SetDisplayState(_mainMenu, DisplayStyle.Flex);
    }
    
    public void TurnLevelsOn()
    {
        TurnOffAllScreens();
        SetDisplayState(_levelsMenu, DisplayStyle.Flex);
    }

    private void SetDisplayState(UIDocument document, DisplayStyle displayStyle)
    {
        document.rootVisualElement.style.display = displayStyle;
    }
}
