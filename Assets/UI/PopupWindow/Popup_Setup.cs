using UnityEngine;
using UnityEngine.UIElements;

namespace PopupTest
{
    public class Popup_Setup : MonoBehaviour
    {
        private void OnEnable()
        {
            UIDocument _ui = GetComponent<UIDocument>();
            VisualElement _root = _ui.rootVisualElement;
    
            PopupWindow _popup = new PopupWindow();
            _root.Add(_popup);
    
            _popup.confirmed += () => Debug.Log("Email send");
    
            _popup.cancelled += () => Debug.Log("Email sending cancelled");
            _popup.cancelled += () => _root.Remove(_popup);
        }
    }

}
