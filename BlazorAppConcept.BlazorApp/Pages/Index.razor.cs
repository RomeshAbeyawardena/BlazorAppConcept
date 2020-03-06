using DNI.Shared.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppConcept.BlazorApp.Shared
{
    public class IndexRazor : ComponentBase
    {
        protected IDictionary<string, IDictionary<string, object>> ComponentDictionary { get; private set; }

        public IndexRazor()
        {
            ComponentDictionary = DictionaryBuilder
                .Create<string, IDictionary<string, object>>()
                .Add("CounterComponent", DictionaryBuilder.Create<string, object>().ToDictionary())
                .ToDictionary();

        }
    }
}
