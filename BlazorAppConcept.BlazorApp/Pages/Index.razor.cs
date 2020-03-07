using DNI.Core.Services;
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
                .Add("CustomerComponent", DictionaryBuilder.Create<string, object>(builder => { builder.Add("CustomerId", 1); }).ToDictionary())
                .ToDictionary();

        }
    }
}
