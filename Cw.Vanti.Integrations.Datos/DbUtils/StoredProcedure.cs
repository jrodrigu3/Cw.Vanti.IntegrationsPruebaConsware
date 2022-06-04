//-----------------------------------------------------------------------
// <copyright file="StoredProcedure.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>8/14/2019 10:13:56 AM</date>
// <summary>Código fuente clase StoredProcedure.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Datos.DbUtils
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Data.SqlTypes;
    using System.Linq;

    /// <summary>
    /// Define la estructura básica de un parámetro de
    /// un procedimiento de almacenado.
    /// </summary>
    public class StoredProcedure
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StoredProcedure"/> class.
        /// </summary>
        /// <param name="procedure">Nombre procedimiento de almacenado.</param>
        public StoredProcedure(string procedure)
            : this(procedure, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoredProcedure"/> class.
        /// </summary>
        /// <param name="procedure">Nombre procedimiento de almacenado.</param>
        /// <param name="parameters">Arreglo de parámetros.</param>
        public StoredProcedure(string procedure, SqlParameter[] parameters)
        {
            if (string.IsNullOrEmpty(procedure))
            {
                throw new ArgumentNullException("procedure");
            }

            this.Name = procedure;
            this.Parameters = new Collection<SqlParameter>();

            if (parameters != null)
            {
                this.AddParameters(parameters);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets el nombre del procedimiento de almacenado.
        /// </summary>
        /// <value>Nombre del procedimiento de almacenado.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Objeto que contiene el nombre y los nombres de los parametros
        /// concatenados. ej: "NombreProcedimiento @param1, @param2,....@paramn"
        /// </summary>
        /// <returns>Objeto que contiene el nombre y los nombres de los parametros concatenados.</returns>
        public string GetNameAndParamsConcat()
        {
            return this.Name + this.Parameters == null ? string.Empty : string.Join(",", this.Parameters.Select(p => p.ParameterName));
        }

        /// <summary>
        /// Gets la instancia del <see cref="SqlParameterCollection"/>
        /// que encapsula los parametros del procedimiento.
        /// </summary>
        /// <value>Instancia del <see cref="SqlParameterCollection"/>
        /// que encapsula los parametros del procedimiento.</value>
        internal ICollection<SqlParameter> Parameters { get; }

        /// <summary>
        /// Obtiene el parámetro localizado enla posición proporcionada.
        /// </summary>
        /// <param name="index">Posición o indice donde se encuentra el evento.</param>
        /// <returns>Cw.Vanti.Integrations.Datos de <see cref="SqlParameter"/> almacenados.</returns>
        public SqlParameter this[int index]
        {
            get
            {
                if (this.Parameters == null || !this.Parameters.Any())
                {
                    return null;
                }

                return this.Parameters.ElementAt(index);
            }
        }

        #endregion

        #region Methods And Functionss

        /// <summary>
        /// Gestiona la validación de los datos básicos de un procedimiento de almacenado.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento de almacenado.</param>
        public static void Validate(StoredProcedure procedure)
        {
            if (procedure == null)
            {
                throw new ArgumentNullException("procedure");
            }

            if (string.IsNullOrEmpty(procedure.Name))
            {
                throw new ArgumentException("Invalid procedure name.");
            }
        }

        /// <summary>
        /// Agrega un parámetro al procedimiento de almacenado.
        /// </summary>
        /// <param name="name">Nombre parámetro.</param>
        /// <param name="value">Valor del prámetro.</param>
        public void AddParameter(string name, object value)
        {
            this.Parameters.Add(new SqlParameter(name, value));
        }

        /// <summary>
        /// Agrega un parámetro al procedimiento de almacenado.
        /// </summary>
        /// <param name="name">Nombre parámetro.</param>
        /// <param name="value">Valor del prámetro.</param>
        /// <param name="dir">Dirección del parámetro.</param>
        public void AddParameter(string name, object value, ParameterDirection dir)
        {
            SqlParameter p = new SqlParameter(name, value);
            p.Direction = dir;
            this.AddParameter(p);
        }

        /// <summary>
        /// Agrega un parámetro al procedimiento de almacenado.
        /// </summary>
        /// <param name="name">Nombre parámetro.</param>
        /// <param name="value">Valor del prámetro.</param>
        /// <param name="dir">Dirección del parámetro.</param>
        /// <param name="type">Tipo de dato personalizado.</param>
        /// <param name="typeName">Nombre del tipo personalizado.</param>
        public void AddParameter(string name, object value, ParameterDirection dir, SqlDbType type, string typeName)
        {
            SqlParameter p = new SqlParameter(name, type)
            {
                Direction = dir,
                SqlDbType = type,
                TypeName = typeName,
                Value = value
            };
            this.AddParameter(p);
        }

        /// <summary>
        /// Agrega un parámetro al procedimiento de almacenado.
        /// </summary>
        /// <param name="p">Instancia de <see cref="SqlParameter"/> con
        /// los datos del parámetro.</param>
        public void AddParameter(SqlParameter p)
        {
            if (p == null)
            {
                throw new ArgumentNullException("p");
            }

            if (p.SqlDbType == SqlDbType.DateTime)
            {
                DateTime sqlMinValue = (DateTime)SqlDateTime.MinValue;

                if (((DateTime)p.Value).CompareTo(sqlMinValue) < 0)
                {
                    p.Value = sqlMinValue;
                }
            }

            this.Parameters.Add(p);
        }

        /// <summary>
        /// Agrega un arreglo de parámetros.
        /// </summary>
        /// <param name="values">Arreglo de parámetros.</param>
        public void AddParameters(SqlParameter[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            if (values.Length == 0)
            {
                throw new ArgumentException("Invalid parámeters.");
            }

            foreach (SqlParameter p in values)
            {
                this.Parameters.Add(p);
            }
        }

        #endregion
    }
}