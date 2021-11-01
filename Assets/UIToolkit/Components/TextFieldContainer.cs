using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI_Toolkit.Components
{
    public class TextFieldContainer : TextFieldContainerBase
    {
        protected new bool canGrabFocus = true;

        
        public TextFieldContainer()
        {
            this.focusable = true;
            _visualInput = new TextField();
            hierarchy.Add(_visualInput);
        }
        void OnInitialized()
        {
            _visualInput.RegisterCallback<FocusEvent>(OnFocus);
            _visualInput.RegisterCallback<FocusOutEvent>(OnFocusLost);
        }

        private void OnFocusLost(FocusOutEvent evt)
        {
            Debug.Log("TextFieldContainer lost focus");
            _visualInput.RemoveFromClassList("focused");
        }

        private void OnFocus(FocusEvent evt)
        {
            Debug.Log("TextFieldContainer received focus");
            _visualInput.AddToClassList("focused");
        }
        
        public new class UxmlFactory : UxmlFactory<TextFieldContainer, TextFieldContainerBase.UxmlTraits> {}
        
        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            
            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
            {
                get { yield break; }
            }

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var textFieldContainer = ve as TextFieldContainer;
            
                if (textFieldContainer == null) return;
                
                textFieldContainer.OnInitialized();
            }
        }
    }
}
