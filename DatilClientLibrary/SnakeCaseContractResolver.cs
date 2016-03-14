using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace DatilClientLibrary
{
    class SnakeCaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            for (int i = propertyName.Length - 1; i > 0; i--)
                if (i > 0 && char.IsUpper(propertyName[i]))
                    propertyName = propertyName.Insert(i, "_");
            return propertyName.ToLower();
        }
    }
}
