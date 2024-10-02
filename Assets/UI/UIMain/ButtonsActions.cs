using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonsActions : MonoBehaviour
{
    [SerializeField] MenuController menuController;
    UIDocument doc = null;
    VisualElement root = null;
    //delegate keyword is a reference of method
    //delegate void TestDelegate();
    //TestDelegate testDelegate;
    VisualElement mapVallon = null;
    VisualElement mapChenes = null;
    VisualElement mapPinParasol = null;
    VisualElement mapAbricotier = null;
    VisualElement mapHollywood = null;
    //VisualElement mapBatiments = null;
    VisualElement mapUtilitaires = null;
    VisualElement mapMediation = null;
    VisualElement mainMap = null;

    void Start()
    {
        menuController = GetComponent<MenuController>();
        doc = menuController.UIDoc();
        root = doc.rootVisualElement;

        mainMap = root.Q<VisualElement>("Map");
        mapVallon = root.Q<VisualElement>("M_Vallon");
        mapChenes = root.Q<VisualElement>("M_Chenes");
        mapPinParasol = root.Q<VisualElement>("M_PinParasol");
        mapAbricotier = root.Q<VisualElement>("M_Abricotier");
        mapHollywood = root.Q<VisualElement>("M_Hollywood");
        //mapBatiments = root.Q<VisualElement>("M_Batiments");
        mapUtilitaires = root.Q<VisualElement>("M_Utilitaires");
        mapMediation = root.Q<VisualElement>("M_Mediation");

        SubscribeHovers();
    }

    void Update()
    {
        
    }

    void SubscribeHovers(/*Button _button, TestDelegate _func*/)
    {
        menuController.ButVallon().RegisterCallback<MouseEnterEvent>(ev => OnMouseHover(mapVallon, Visibility.Visible));
        menuController.ButVallon().RegisterCallback<MouseLeaveEvent>(ev => OnMouseHover(mapVallon, Visibility.Hidden));

        menuController.ButAbricotier().RegisterCallback<MouseEnterEvent>(ev => OnMouseHover(mapAbricotier, Visibility.Visible));
        menuController.ButAbricotier().RegisterCallback<MouseLeaveEvent>(ev => OnMouseHover(mapAbricotier, Visibility.Hidden));

        menuController.ButChenes().RegisterCallback<MouseEnterEvent>(ev => OnMouseHover(mapChenes, Visibility.Visible));
        menuController.ButChenes().RegisterCallback<MouseLeaveEvent>(ev => OnMouseHover(mapChenes, Visibility.Hidden));

        menuController.ButPinParasol().RegisterCallback<MouseEnterEvent>(ev => OnMouseHover(mapPinParasol, Visibility.Visible));
        menuController.ButPinParasol().RegisterCallback<MouseLeaveEvent>(ev => OnMouseHover(mapPinParasol, Visibility.Hidden));


        menuController.ButHollywood().RegisterCallback<MouseEnterEvent>(ev => OnMouseHover(mapHollywood, Visibility.Visible));
        menuController.ButHollywood().RegisterCallback<MouseLeaveEvent>(ev => OnMouseHover(mapHollywood, Visibility.Hidden));

        menuController.ButMediation().RegisterCallback<MouseEnterEvent>(ev => OnMouseHover(mapMediation, Visibility.Visible));
        menuController.ButMediation().RegisterCallback<MouseLeaveEvent>(ev => OnMouseHover(mapMediation, Visibility.Hidden));

        menuController.ButUtilitaires().RegisterCallback<MouseEnterEvent>(ev => OnMouseHover(mapUtilitaires, Visibility.Visible, DisplayStyle.Flex));
        menuController.ButUtilitaires().RegisterCallback<MouseLeaveEvent>(ev => OnMouseHover(mapUtilitaires, Visibility.Hidden, DisplayStyle.None));
    }

    private void OnMouseHover(VisualElement _map, Visibility _vis, DisplayStyle _dis = DisplayStyle.Flex)
    {
        _map.style.visibility = _vis;
        _map.style.display = _dis; // For Utilitaires, childrens don't disapear when modify visibility, so optionnal modify Display

        // Réduire l'opacité du fond pour mieux voir les éléments en surbrillance
        // Ça se fait mais l'opacité ne se voit pas à l'écran sauf si elle est de 0
        if (_vis == Visibility.Visible) {
            //mainMap.style.unityBackgroundImageTintColor = new StyleColor(new Color(255, 255, 255, 150));
            mainMap.style.opacity = new StyleFloat(50);
        } else
        {
            //mainMap.style.unityBackgroundImageTintColor = new StyleColor(new Color(255, 255, 255, 255));
            mainMap.style.opacity = new StyleFloat(100);
        }
        Debug.Log(mainMap.style.opacity.value);
    }

}
