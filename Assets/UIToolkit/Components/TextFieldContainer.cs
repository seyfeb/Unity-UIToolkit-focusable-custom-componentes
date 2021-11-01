using UnityEngine;
using UnityEngine.UIElements;

namespace UI_Toolkit.Components
{
    public class TextFieldContainer : TextFieldContainerBase
    {
        public TextFieldContainer()
        {
            _visualInput = new TextField();
            hierarchy.Add(_visualInput);
        }
        
        public new class UxmlFactory : UxmlFactory<TextFieldContainer, TextFieldContainerBase.UxmlTraits> {}
    }
}
