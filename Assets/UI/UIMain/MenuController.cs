using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject goManager;
    [SerializeField] ZonesManager manager = null;
    string managerTag = "Manager";

    [SerializeField] ZoneParent selected = null;
    [SerializeField] VisualElement actual = null;
    //UIDoc is the doc where is UI Toolkit, our UXML 
    UIDocument doc = null;
    #region Buttons
    Button butVallon = null;
    Button butChenes = null;
    Button butPinParasol = null;
    Button butAbricotier = null;
    Button butHollywood = null;
    Button butUtilitaires = null;
    Button butMediation = null; //Ancien bouton batiments
    Button butClose = null;
    #endregion Buttons
    #region Windows
    VisualElement wVallon = null;
    VisualElement wChenes = null;
    VisualElement wHollywood = null;
    VisualElement wPinParasol = null;
    VisualElement wMediation = null;
    VisualElement wUtilitaires = null;
    VisualElement wAbricotier = null;
    #endregion Windows
    #region Names
    const string butVallonName = "B_Vallon";
    const string butChenesName = "B_Chenes";
    const string butPinParasolName = "B_PinParasol";
    const string butAbricotierName = "B_Abricotier";
    const string butHollywoodName = "B_Hollywood";
    const string butMediationName = "B_Mediation";
    const string butUtilitairesName = "B_Utilitaires";
    const string butCloseName = "B_Close";
    
    const string wVallonName = "W_Vallon";
    const string wChenesName = "W_Chenes";
    const string wPinParasolName = "W_PinParasol";
    const string wAbricotierName = "W_Abricotier";
    const string wHollywoodName = "W_Hollywood";
    const string wMediationName = "W_Mediation";
    const string wUtilitairesName = "W_Utilitaires";
    #endregion Names
    #region Getters
    public UIDocument UIDoc() { return doc; }

    public Button ButVallon() {  return butVallon; }
    public Button ButChenes() { return butChenes; }
    public Button ButPinParasol() { return butPinParasol; }
    public Button ButAbricotier() { return butAbricotier; }
    public Button ButHollywood() { return butHollywood; }
    public Button ButMediation() { return butMediation; }
    public Button ButUtilitaires() { return butUtilitaires; }
    #endregion Getters


    private void Awake()
    {
        goManager = GameObject.FindGameObjectWithTag(managerTag);
        doc = GetComponent<UIDocument>();
        VisualElement _root = doc.rootVisualElement;
        //Buttons
        FindButtons(_root);
        SubscribeButtons();
        //Windows
        Init();
        //InvokeRepeating("SetCloseButtonVisibility", .2f, .1f);
    }


    private void Start()
    {
        //manager = goManager.GetComponent<ZonesManager>();
        SetCloseButtonVisibility();
    }

    void FindButtons(VisualElement _root)
    {
        //Get button by Query, it's a request a type <Button> and an optionnal name "B_Vallon"
        butVallon = _root.Q<Button>(butVallonName);
        butChenes = _root.Q<Button>(butChenesName);
        butPinParasol = _root.Q<Button>(butPinParasolName);
        butAbricotier = _root.Q<Button>(butAbricotierName);
        butHollywood = _root.Q<Button>(butHollywoodName);
        butMediation = _root.Q<Button>(butMediationName);
        butUtilitaires = _root.Q<Button>(butUtilitairesName);
        butClose = _root.Q<Button>(butCloseName);
        //butMute = _root.Q<Button>("B_Mute");
    }

    void SubscribeButtons()
    {
        butVallon.clicked += VallonButtonClicked;
        butChenes.clicked += ChenesButtonClicked;
        butPinParasol.clicked += PinParasolButtonClicked;
        butAbricotier.clicked += AbricotierButtonClicked;
        butHollywood.clicked += HollywoodButtonClicked;
        butMediation.clicked += MediationButtonClicked;
        butUtilitaires.clicked += UtilitairesButtonClicked;
        butClose.clicked += CloseButtonClicked;
        //butMute.clicked += MuteButtonClicked;
    }

    void Init()
    {
        //Set var
        wVallon = doc.rootVisualElement.Q<VisualElement>(wVallonName);
        wChenes = doc.rootVisualElement.Q<VisualElement>(wChenesName);
        wHollywood = doc.rootVisualElement.Q<VisualElement>(wHollywoodName);
        wPinParasol = doc.rootVisualElement.Q<VisualElement>(wPinParasolName);
        wMediation = doc.rootVisualElement.Q<VisualElement>(wMediationName);
        wUtilitaires = doc.rootVisualElement.Q<VisualElement>(wUtilitairesName);
        wAbricotier = doc.rootVisualElement.Q<VisualElement>(wAbricotierName);

        ResetVisibility(wVallon);
        ResetVisibility(wChenes);
        ResetVisibility(wUtilitaires);
        ResetVisibility(wMediation);
        ResetVisibility(wAbricotier);
        ResetVisibility(wPinParasol);
        ResetVisibility(wHollywood);
    }

    //private void MuteButtonClicked()
    //{
    //    //Reverse bool
    //    muted = !muted;
    //    //Acceed to background image of button
    //    var bg = butMute.style.backgroundImage;
    //    //FromSprite() create a backgroung from sprite, change if muted or not
    //    bg.value = Background.FromSprite(muted ? mutedSprite : unmutedSprite);
    //    //Change bg
    //    butMute.style.backgroundImage = bg;

    //    //Mute sound if button is muted
    //    AudioListener.volume = muted ? 0 : 1;
    //}
    #region ActionZones
    private void CloseButtonClicked()
    {
        if (actual == null) return;
        DeselectVE();
        SetCloseButtonVisibility();
    }

    private void VallonButtonClicked()
    {
        Debug.Log("Vallon clicked");
        /*If Zone is Go
        // Deselect();
        // Find Vallon as GO
        // selected = FindObjectOfType<Vallon>();
        // Change color of sprite renderer with function
        // selected.ChangeZoneTint(selected.GetNewColor());*/

        //If Zone is UI toolkit
        DeselectVE();
        actual = wVallon;
        //Make appear window Vallon
        if (actual != null) Debug.Log(actual.style.visibility);
        SwapVisibility(actual);
        SetCloseButtonVisibility();
    }
    
    private void ChenesButtonClicked()
    {
        Debug.Log("Chenes clicked");
        DeselectVE();
        actual = wChenes;
        if (actual != null) Debug.Log(actual.style.visibility);
        SwapVisibility(actual);
        SetCloseButtonVisibility();
    }
    
    private void PinParasolButtonClicked()
    {
        Debug.Log("PinParasol clicked");
        DeselectVE();
        actual = wPinParasol;
        if (actual != null) Debug.Log(actual.style.visibility);
        SwapVisibility(actual);
        SetCloseButtonVisibility();
    }

    private void UtilitairesButtonClicked()
    {
        Debug.Log("Utilitaires clicked");
        DeselectVE();
        actual = wUtilitaires;
        if (actual != null) Debug.Log(actual.style.visibility);
        SwapVisibility(actual);
        SetCloseButtonVisibility();
    }

    private void MediationButtonClicked()
    {
        Debug.Log("Batiments clicked");
        DeselectVE();
        actual = wMediation;
        if (actual != null) Debug.Log(actual.style.visibility);
        SwapVisibility(actual);
        SetCloseButtonVisibility();
    }

    private void HollywoodButtonClicked()
    {
        Debug.Log("Hollywood clicked");
        DeselectVE();
        actual = wHollywood;
        if (actual != null) Debug.Log(actual.style.visibility);
        SwapVisibility(actual);
        SetCloseButtonVisibility();
    }

    private void AbricotierButtonClicked()
    {
        Debug.Log("Abricotier clicked");
        DeselectVE();
        actual = wAbricotier;
        if (actual != null) Debug.Log(actual.style.visibility);
        SwapVisibility(actual);
        SetCloseButtonVisibility();
    }

    #endregion ActionZones

    void Deselect()
    {
        if (!selected) return;
        selected.ResetColor();
        selected = null;
    }

    void DeselectVE()
    {
        if (actual == null) return;
        SwapVisibility(actual);
        actual = null;
        //SetCloseButtonVisibility();
    }

    void SwapVisibility(VisualElement _actual)
    {
        if (_actual.style.display == DisplayStyle.None)
        {
            _actual.style.display = DisplayStyle.Flex;
            return;
        }
        if (_actual.style.display == DisplayStyle.Flex)
        {
            _actual.style.display = DisplayStyle.None;
            return;
        }
    }

    void ResetVisibility(VisualElement _actual)
    {
        if (_actual == null) return;
        _actual.style.display = DisplayStyle.None;
    }

    void SetCloseButtonVisibility()
    {
        if (actual == null) { 
            butClose.style.display = DisplayStyle.None;
            return;        
        }
        butClose.style.display = DisplayStyle.Flex;
    }
}
