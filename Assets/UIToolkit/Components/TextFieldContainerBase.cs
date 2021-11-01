using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI_Toolkit.Components
{
    public abstract class TextFieldContainerBase : VisualElement
    {
        protected VisualElement _visualInput;
        public TextFieldContainerBase(){}

        void OnInitialized()
        {
            _visualInput.RegisterCallback<FocusEvent>(OnFocus);
            _visualInput.RegisterCallback<FocusOutEvent>(OnFocusLost);
        }

        private void OnFocusLost(FocusOutEvent evt)
        {
            Debug.Log("TextField lost focus");
            _visualInput.RemoveFromClassList("focused");
        }

        private void OnFocus(FocusEvent evt)
        {
            Debug.Log("TextField received focus");
            _visualInput.AddToClassList("focused");
        }
        
        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            
            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
            {
                get { yield break; }
            }

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var textField = ve as TextFieldContainerBase;
            
                if (textField == null) return;
                
                textField.OnInitialized();
            }
        }
    }
}
