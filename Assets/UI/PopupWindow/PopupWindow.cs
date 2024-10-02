using UnityEngine;
using System;
using UnityEngine.UIElements;

namespace PopupTest
{
    public class PopupWindow : VisualElement
    {
        [UnityEngine.Scripting.Preserve]
        public new class UxmlFactory : UxmlFactory<PopupWindow> { }

        // string for find in Resources
        const string styleResource = "PopupWindowStyleSheet";
        // name of style
        const string ussPopup = "popup-window";
        const string ussPopupContainer = "popup-container";
        const string ussHorContainer = "horizontal-container";
        const string ussPopupMsg = "popup-msg";
        const string ussPopupButton = "popup-button";
        const string ussCancel = "button-cancel";
        const string ussConfirm = "button-confirm";

        public PopupWindow()
        {
            //Search in "Resources" folder the "styleResource"
            styleSheets.Add(Resources.Load<StyleSheet>(styleResource));
            //apply style
            AddToClassList(ussPopupContainer);
            //create element
            VisualElement _window = new VisualElement();
            //apply style on element
            _window.AddToClassList(ussPopup);
            //add element in hierarchy
            hierarchy.Add(_window);

            // tEXT sECTION
            // Create element
            VisualElement _horizontalContainerText = new VisualElement();
            // Apply style
            _horizontalContainerText.AddToClassList(ussHorContainer);
            // Add element to window
            _window.Add(_horizontalContainerText);

            Label _msgLabel = new Label();
            //Bad thing to text directly in code
            _msgLabel.text = "Do you really want the red pill ?";
            _msgLabel.AddToClassList(ussPopupMsg);
            _horizontalContainerText.Add(_msgLabel);

            // Button Section
            VisualElement _horizontalContainerButton = new VisualElement();
            _horizontalContainerButton.AddToClassList(ussHorContainer);
            _window.Add(_horizontalContainerButton);

            Button _confirmButton = new Button() { text = "CONFIRM" };
            _confirmButton.AddToClassList(ussPopupButton);
            _confirmButton.AddToClassList(ussConfirm);
            _horizontalContainerButton.Add(_confirmButton);
            
            Button _cancelButton = new Button() { text = "CANCEL" };
            _cancelButton.AddToClassList(ussPopupButton);
            _cancelButton.AddToClassList(ussCancel);
            _horizontalContainerButton.Add(_cancelButton);

            // Buttons Functions
            _confirmButton.clicked += OnConfirm;
            _cancelButton.clicked += OnCancel;
        }

        public event Action confirmed;
        public event Action cancelled;

        void OnConfirm()
        {
            confirmed?.Invoke();
        }

        void OnCancel()
        {
            cancelled?.Invoke();
        }
    }

}

