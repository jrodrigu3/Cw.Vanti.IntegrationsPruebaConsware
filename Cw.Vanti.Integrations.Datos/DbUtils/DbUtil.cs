//-----------------------------------------------------------------------
// <copyright file="DbUtil.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>8/14/2019 10:27:19 AM</date>
// <summary>Código fuente clase DbUtil.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Datos.DbUtils
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Proporciona métodos útiles para la manipulación de datos y
    /// mapeo y encapsulación de datos.
    /// </summary>
    public static class DbUtil
    {
        #region Attributes

        #endregion

        #region Constructors

        #endregion

        #region Properties

        #endregion

        #region Methods And Functionss

        /// <summary>
        /// Obtiene una colección de objetos del tipo especificado, almacenados
        /// en la instancia de <see cref="DataRow"/> proporcionada.
        /// </summary>
        /// <typeparam name="T">Tipo generalizado que representa el tipo de
        /// dato contenido en la instancia de <see cref="DataRow"/>.</typeparam>
        /// <param name="row">Fila donde se encuentran los valores
        /// de la instancia a obtener.</param>
        /// <returns>Instancia del tipo de dato contenido en la
        /// instancia de <see cref="DataRow"/> proporcinada.</returns>
        public static T LoadData<T>(DataRow row)
             where T : class, new()
        {
            if (row == null)
            {
                return default(T);
            }

            Dictionary<string, string> columns = GetColumnNames<T>(row.Table.Columns);
            return LoadData<T>(row, columns);
        }

        /// <summary>
        /// Obtiene una colección de objetos del tipo especificado, almacenados
        /// en la instanda de <see cref="DataRow"/>  proporcionado.
        /// </summary>
        /// <typeparam name="T">Tipo generalizado que representa el tipo de dato contenido
        /// en la instancia de <see cref="DataRow"/>.</typeparam>
        /// <param name="row">Fila donde se encuentran los valores
        /// de la instancia a obtener.</param>
        /// <param name="columns">Diccionario que relaciona el nombre
        /// de la propiedad con los nombres de sus columna.</param>
        /// <returns>Instancia del tipo de dato contenido en
        /// la instancia de <see cref="DataRow"/> proporcinada.</returns>
        public static T LoadData<T>(DataRow row, Dictionary<string, string> columns)
             where T : class, new()
        {
            if (row == null || row.Table == null || row.Table.Columns == null || columns == null)
            {
                return default(T);
            }

            T ans = new T();

            foreach (KeyValuePair<string, string> c in columns)
            {
                PropertyInfo prop = ans.GetType().GetProperty(c.Value);

                if (prop == null)
                {
                    continue;
                }

                SetPropertyValue(ans, prop, row[c.Value]);
            }

            return ans;
        }

        /// <summary>
        /// Obtiene una colección de objetos del tipo especificado, almacenados
        /// en la instancia de <see cref="DataTable"/> proporcionada.
        /// </summary>
        /// <typeparam name="T">Tipo generalizado que representa el tipo de dato almacenado
        /// en la colección.</typeparam>
        /// <param name="data">Cw.Vanti.Integrations.Datos de donde será generada la colección.</param>
        /// <returns>Colección con los datos del tipo especificado.</returns>
        public static ICollection<T> LoadData<T>(DataTable data)
             where T : class, new()
        {
            if (data == null || data.Rows == null || data.Rows.Count == 0)
            {
                return Enumerable.Empty<T>().ToList();
            }

            Dictionary<string, string> columns = GetColumnNames<T>(data.Columns);
            ICollection<T> ans = new Collection<T>();

            foreach (DataRow row in data.Rows)
            {
                T obj = LoadData<T>(row, columns);
                ans.Add(obj);
            }

            return ans;
        }

        /// <summary>
        /// Obtiene la sintaxis que permite invocar un procedimiento de almacenado.
        /// </summary>
        /// <param name="sp">Name of the procedure.</param>
        /// <param name="p">The parameters.</param>
        /// <returns>Cadena con la sintaxis de llamado de un procedimiento de almacenado.</returns>
        internal static string GetStoredProcedureSyntax(string sp, ICollection<SqlParameter> p)
        {
            StringBuilder sb = new StringBuilder(sp);

            if (p != null && p.Any())
            {
                sb.Append(StringFormat.Format(
                    " @{0}={1}",
                    p.ElementAt(0).ParameterName.Replace("@", string.Empty),
                    FormatFieldValue(p.ElementAt(0).Value)));

                for (int i = 1; i < p.Count; i++)
                {
                    sb.Append(StringFormat.Format(
                        ", @{0}={1}",
                        p.ElementAt(i).ParameterName.Replace("@", string.Empty),
                        FormatFieldValue(p.ElementAt(i).Value)));
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Dado un valor, aplica el formato adecuado con base
        /// al tipo de dato que corresponda.
        /// </summary>
        /// <param name="val">Valor a formatear.</param>
        /// <returns>EL valor con el formato correcto.</returns>
        internal static string FormatFieldValue(object val)
        {
            string formatValue = string.Empty;

            if (val != null)
            {
                if (val is Guid || val is DateTime || val is string || val is TimeSpan)
                {
                    formatValue = val.ToString();

                    if (val is DateTime)
                    {
                        formatValue = FormatDateTime((DateTime)val, "-");
                    }

                    formatValue = StringFormat.Format("'{0}'", formatValue);
                }
                else if (val is double)
                {
                    formatValue = ((double)val).ToString(NumberFormatInfo.InvariantInfo).Replace(',', '.');
                }
                else if (val is bool)
                {
                    formatValue = ((bool)val) ? "1" : "0";
                }
                else if (val is Enum)
                {
                    formatValue = ((int)val).ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    formatValue = val.ToString();
                }
            }
            else
            {
                formatValue = "NULL";
            }

            return formatValue;
        }

        /// <summary>
        /// Formatea la fecha dada con el formato yyyy-mm-dd, donde el
        /// caracter '-' puede ser cuaquiera especificado por el parametro separator.
        /// </summary>
        /// <param name="date">Fecha a formatear.</param>
        /// <param name="separator">Caracter empleado para formatear.</param>
        /// <returns>La fecha formateada.</returns>
        internal static string FormatDateTime(DateTime date, string separator)
        {
            string format = StringFormat.Format("yyyy{0}MM{0}dd", separator);
            return StringFormat.Format("{0:" + format + "} {0:HH:mm:ss}", date);
        }

        /// <summary>
        /// Almacena el valor proporcionado a la propiedad de la instancia especificada.
        /// </summary>
        /// <param name="obj">Instancia que contiene la propiedad.</param>
        /// <param name="prop">Propiedad cuyo valor sera configurado.</param>
        /// <param name="val">Valor a establecer.</param>
        private static void SetPropertyValue(object obj, PropertyInfo prop, object val)
        {
            switch (Type.GetTypeCode(val.GetType()))
            {
                case TypeCode.SByte:
                    prop.SetValue(obj, Convert.ToByte(val, NumberFormatInfo.InvariantInfo));
                    break;
                case TypeCode.Int16:
                    prop.SetValue(obj, Convert.ToInt16(val, NumberFormatInfo.InvariantInfo));
                    break;
                case TypeCode.Int32:
                    if (prop.PropertyType.ToString().ToUpper(CultureInfo.InvariantCulture).Equals("SYSTEM.BOOLEAN"))
                    {
                        prop.SetValue(obj, Convert.ToBoolean(val, CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        prop.SetValue(obj, Convert.ToInt32(val, NumberFormatInfo.InvariantInfo));
                    }
                    break;
                case TypeCode.Int64:
                    prop.SetValue(obj, Convert.ToInt64(val, NumberFormatInfo.InvariantInfo));
                    break;
                case TypeCode.Single:
                    prop.SetValue(obj, Convert.ToSingle(val, NumberFormatInfo.InvariantInfo));
                    break;
                case TypeCode.Double:
                    prop.SetValue(obj, Convert.ToDouble(val, NumberFormatInfo.InvariantInfo));
                    break;
                case TypeCode.Decimal:
                    prop.SetValue(obj, Convert.ToDecimal(val, NumberFormatInfo.InvariantInfo));
                    break;
                case TypeCode.String:
                    prop.SetValue(obj, Convert.ToString(val, CultureInfo.InvariantCulture).Trim());
                    break;
                case TypeCode.Boolean:
                    prop.SetValue(obj, Convert.ToBoolean(val, CultureInfo.InvariantCulture));
                    break;
                case TypeCode.DateTime:
                    prop.SetValue(obj, Convert.ToDateTime(val, CultureInfo.InvariantCulture));
                    break;
            }
        }

        /// <summary>
        /// Obtiene los nombres de las columnas y los campos que se deben
        /// tener en cuenta a la hora de obtner los datos del origen de datos.
        /// </summary>
        /// <typeparam name="T">Tipo generalizado que representa el tipo de dato contenido
        /// en el origen de datos.</typeparam>
        /// <param name="columns">Colección con los nombres de las columnas.</param>
        /// <returns>Diccionario que relaciona el nombre de la propiedad con los
        /// nombres de su columna.</returns>
        private static Dictionary<string, string> GetColumnNames<T>(DataColumnCollection columns)
            where T : class, new()
        {
            Dictionary<string, string> ans = new Dictionary<string, string>();
            T obj = new T();
            PropertyInfo[] props = obj.GetType().GetProperties();
            int count = 0;

            foreach (PropertyInfo p in props)
            {
                if (columns.Contains(p.Name))
                {
                    ans.Add(p.Name, p.Name);
                    count++;

                    if (count == columns.Count)
                    {
                        break;
                    }
                }
            }

            return ans;
        }

        #endregion
    }
}