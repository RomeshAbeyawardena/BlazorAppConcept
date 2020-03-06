using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppConcept.BlazorApp.Shared.Components
{
    public class DynamicComponentRazor : ComponentBase
    {
        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public string Namespace { get; set; }

        [Parameter]
        public IDictionary<string, object> Parameters { get; set; }

        protected RenderFragment ComponentContent { get; private set; }

        protected override void OnInitialized()
        {
            ComponentContent = builder =>
            {
                if(string.IsNullOrWhiteSpace(Namespace))
                    Namespace = "BlazorAppConcept.BlazorApp.Shared.Components";

                var componentType = Type.GetType(string.Format("{0}.{1}",
                    Namespace, Name));

                if(componentType == null)
                    return;
                var sequence = 0;
                builder.OpenComponent(sequence++, componentType);

                if(Parameters != null)
                    foreach(var keyValue in Parameters)
                        builder.AddAttribute(sequence++, keyValue.Key, keyValue.Value);

                builder.CloseComponent();
            };
        }
    }
}
