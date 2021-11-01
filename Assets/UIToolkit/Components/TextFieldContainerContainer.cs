using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI_Toolkit.Components
{
    public class TextFieldContainerContainer : VisualElement
    {
        protected new bool canGrabFocus = true;
        private TextFieldContainer _textFieldContainerReference;
        public TextFieldContainerContainer()
        {
            this.focusable = true;
            _textFieldContainerReference = new TextFieldContainer();
            hierarchy.Add(_textFieldContainerReference);
        }

        void OnInitialized()
        {
            RegisterCallback<FocusEvent>(OnFocus);
            RegisterCallback<FocusOutEvent>(OnFocusLost);
        }

        private void OnFocusLost(FocusOutEvent evt)
        {
            Debug.Log("TextFieldContainer lost focus");
        }

        private void OnFocus(FocusEvent evt)
        {
            Debug.Log("TextFieldContainer received focus");
        }
        
        public new class UxmlFactory : UxmlFactory<TextFieldContainerContainer, VisualElement.UxmlTraits> {}
        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            
            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
            {
                get { yield break; }
            }

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var textFieldContainerContainer = ve as TextFieldContainerContainer;
            
                if (textFieldContainerContainer == null) return;
                
                textFieldContainerContainer.OnInitialized();
            }
        }
    }
}
