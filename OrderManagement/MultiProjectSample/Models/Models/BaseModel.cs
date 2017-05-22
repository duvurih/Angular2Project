using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MultiProjectSample.Models.Models
{
    public class BaseModel
    {
        public Dictionary<string, string> GetValidationDefinition(Type type)
        {
            var modelMetaData = ModelMetadataProviders.Current.GetMetadataForProperties(this, type);

            var mvcContext = new ControllerContext();
            var validationAttributes = new Dictionary<string, string>();
            foreach (var metaDataForProperty in modelMetaData)
            {
                var validationRulesForProperty = metaDataForProperty.GetValidators(mvcContext).SelectMany(v => v.GetClientValidationRules());
                foreach (ModelClientValidationRule rule in validationRulesForProperty)
                {
                    string key = metaDataForProperty.PropertyName + "-" + rule.ValidationType;
                    validationAttributes.Add(key, System.Web.HttpUtility.HtmlEncode(rule.ErrorMessage ?? string.Empty));
                    key = key + "-";
                    foreach (KeyValuePair<string, object> pair in rule.ValidationParameters)
                    {
                        validationAttributes.Add(key + pair.Key, System.Web.HttpUtility.HtmlAttributeEncode(pair.Value != null ? Convert.ToString(pair.Value, System.Globalization.CultureInfo.InvariantCulture) : string.Empty));
                    }
                }
            }
            return validationAttributes;
        }

    }
}