using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNI.Core.Shared.Extensions;

namespace BlazorAppConcept.BlazorApp.Shared.Components
{
    public class DynamicComponentRazor : ComponentBase
    {
        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public string Namespace { get; set; } = "BlazorAppConcept.BlazorApp.Shared.Components";

        [Parameter]
        public IDictionary<string, object> Parameters { get; set; }

        protected RenderFragment ComponentContent { get; private set; }

        protected override void OnInitialized()
        {
            ComponentContent = this.RenderComponent(Name, Namespace, Parameters);
        }
    }
}
