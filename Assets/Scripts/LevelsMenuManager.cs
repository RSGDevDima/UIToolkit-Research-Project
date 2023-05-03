using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelsMenuManager : MonoBehaviour
{
    private const string CLICK_TEXT_TEMPLATE = "You clicked {0} times";
    private UIDocument _uiDocument;
    private Button _backButton;
    private Button _increaseButton;
    private Label _amountLabel;
    private VisualElement _rootVisualElement;

    private int _clickAmount = 0;

    private void OnEnable()
    {
        GetUIDocument();
        FindUIPartials();
        FindElements();
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
        _backButton.RegisterCallback<ClickEvent>(BackClick);
        _increaseButton.RegisterCallback<ClickEvent>(IncreaseClick);
    }

    private void IncreaseClick(ClickEvent evt)
    {
        _clickAmount++;
        SetClickAmount(_clickAmount);
    }

    private void SetClickAmount(int amount)
    {
        _amountLabel.text = string.Format(CLICK_TEXT_TEMPLATE, amount);
    }

    private void FindElements()
    {
        _backButton = _rootVisualElement.Q("go-back") as Button;
        _increaseButton = _rootVisualElement.Q("levels-menu_increase-amount") as Button;
        _amountLabel = _rootVisualElement.Q("levels-menu_amount_label") as Label;
    }
    
    private void UnRegisterButtonEvents()
    {
        _backButton.UnregisterCallback<ClickEvent>(BackClick);
    }

    public void BackClick(ClickEvent evt)
    {
        MenuManager.Instance.TurnMenuOn();
    }
}
