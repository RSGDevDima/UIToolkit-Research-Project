using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuManager : PanelEventHandler
{
    private UIDocument _uiDocument;
    private Button _startButton;
    private Button _exitButton;
    private Button _changeThemeButton;
    private VisualElement _rootVisualElement;

    private const string DARK_THEME_CLASSNAME = "dark";
    private const string START_BUTTON_ID = "main-menu_start-game";
    private const string EXIT_BUTTON_ID = "main-menu_exit";
    private const string CHANGE_THEME_BUTTON_ID = "main-menu_change-theme";

    private void OnEnable()
    {
        GetUIDocument();
        FindUIPartials();
        FindButtons();
        RegisterButtonEvents();
    }

    private void GetUIDocument()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void FindUIPartials()
    {
        _rootVisualElement = _uiDocument.rootVisualElement;
    }

    private void OnDisable()
    {
        UnRegisterButtonEvents();
    }

    private void RegisterButtonEvents()
    {
        _startButton.RegisterCallback<ClickEvent>(StartClick);
        _exitButton.RegisterCallback<ClickEvent>(ExitClick);
        _changeThemeButton.RegisterCallback<ClickEvent>(ChangeThemeClick);
    }
    
    private void FindButtons()
    {
        _startButton = _rootVisualElement.Q(START_BUTTON_ID) as Button;
        _exitButton = _rootVisualElement.Q(EXIT_BUTTON_ID) as Button;
        _changeThemeButton = _rootVisualElement.Q(CHANGE_THEME_BUTTON_ID) as Button;
    }
    
    private void UnRegisterButtonEvents()
    {
        _startButton.UnregisterCallback<ClickEvent>(StartClick);
        _exitButton.UnregisterCallback<ClickEvent>(ExitClick);
        _changeThemeButton.UnregisterCallback<ClickEvent>(ChangeThemeClick);
    }
    
    private void ChangeThemeClick(ClickEvent evt)
    {
        bool isDarkTheme = _rootVisualElement.ClassListContains(DARK_THEME_CLASSNAME);
        
        if(isDarkTheme)
            _rootVisualElement.RemoveFromClassList(DARK_THEME_CLASSNAME);
        else
            _rootVisualElement.AddToClassList(DARK_THEME_CLASSNAME);
    }

    public void StartClick(ClickEvent evt)
    {
        MenuManager.Instance.TurnLevelsOn();
    }
    
    public void ExitClick(ClickEvent evt)
    {
        Debug.Log("Exit clicked");
        
    }
}