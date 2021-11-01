using UnityEngine;
using UnityEngine.UIElements;

namespace UI_Toolkit.Components
{
    public class TextFieldContainerContainer : VisualElement
    {
        private TextFieldContainer _textFieldContainerReference;
        public TextFieldContainerContainer()
        {
            _textFieldContainerReference = new TextFieldContainer();
            hierarchy.Add(_textFieldContainerReference);
        }
        
        public new class UxmlFactory : UxmlFactory<TextFieldContainerContainer, VisualElement.UxmlTraits> {}
    }
}
