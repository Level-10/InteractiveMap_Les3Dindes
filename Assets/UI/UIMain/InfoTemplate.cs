using UnityEngine;
using UnityEngine.UIElements;

namespace Templates
{
    public class InfoTemplate : VisualElement
    {
        [UnityEngine.Scripting.Preserve]
        public new class UxmlFactory : UxmlFactory<InfoTemplate> { }

        const string styleResource = "TemplateStyleSheet";
        //style names
        const string ussWindow = "scroll-window";

        public InfoTemplate()
        {
            // Search style in Resource folder
            styleSheets.Add(Resources.Load<StyleSheet>(styleResource));
            //apply style
            AddToClassList(ussWindow);
            //create element
            VisualElement _window = new VisualElement();
            //apply style
            //_element.AddToClassList():
            //add element in hierarchy
            hierarchy.Add(_window);
        }
    }

}