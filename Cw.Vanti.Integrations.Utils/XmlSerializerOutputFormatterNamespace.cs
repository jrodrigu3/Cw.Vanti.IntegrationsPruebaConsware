//----------------------------------------------------
// <copyright file="ResponseResult.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>Arnold Charris</author>
// <date>05-02-2021</date>
// <summary>Definición de atributos para la clase ResponseResult.</summary>
//----------------------------------------------------

namespace Cw.Vanti.Integrations.Utils
{
    using Microsoft.AspNetCore.Mvc.Formatters;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Gets la estructura de las respuesta para los controller.
    /// </summary>
    public class XmlSerializerOutputFormatterNamespace : XmlSerializerOutputFormatter
    {
        protected override void Serialize(XmlSerializer xmlSerializer, XmlWriter xmlWriter, object value)
        {
            //applying "empty" namespace will produce no namespaces
            var emptyNamespaces = new XmlSerializerNamespaces();
            emptyNamespaces.Add("", "any-non-empty-string");
            xmlSerializer.Serialize(xmlWriter, value, emptyNamespaces);
        }
    }
}
