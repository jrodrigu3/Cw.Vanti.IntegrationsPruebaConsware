//-----------------------------------------------------------------------
// <copyright file="EfDatosUow.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author>JacoboCantillo</author>
// <date>2/20/2019 7:18:47 PM</date>
// <summary>Código fuente clase EfDatosUow.</summary>
//-----------------------------------------------------------------------
namespace Cw.Vanti.Integrations.Datos
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// EfUnitOfWork class.
    /// </summary>
    public class EfDatosUow : IDisposable, IDatosUow
    {
        #region Attributes

        /// <summary>
        /// Representa el contexto EF de conexión con la base de datos.
        /// </summary>
        private AppDbContext context;

        /// <summary>
        /// Representa la instancia del repositorio que gestiona los datos de la entidad <see cref="TransaccionVanti"/>.
        /// </summary>
        // private ITransaccionVantiRepository transaccionesVantiRepository;

        /// <summary>
        /// Representa la instancia del repositorio que gestiona los datos de la entidad <see cref="IRestauranteRepository"/>.
        /// </summary>
        private IRestauranteRepository restauranteRepository;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EfDatosUow"/> class.
        /// </summary>
        /// <param name="configuration">Objeto que contiene la configuracion de aplicativo.</param>
        public EfDatosUow(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets el acceso a los repositorios de datos.
        /// </summary>
        public AppDbContext Context
        {
            get
            {
                if (this.context == null)
                {
                    this.context = new AppDbContext(this.Configuration);
                }

                return context;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether Objeto que contiene la configuracion de aplicativo.
        /// </summary>
        /// <value>Objeto que contiene la configuracion de aplicativo.</value>
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Gets el repositorio que gestiona los datos del transacciones vanti.
        /// </summary>
        //public ITransaccionVantiRepository TransaccionVantiRepository
        //{
        //    get { return this.transaccionesVantiRepository ?? (this.transaccionesVantiRepository = new TransaccionVantiRepository(this)); }
        //}

        /// <summary>
        /// Gets el repositorio que gestiona los datos del transacciones vanti.
        /// </summary>
        public IRestauranteRepository RestauranteRepository
        {
            get { return this.restauranteRepository ?? (this.restauranteRepository = new RestauranteRepository(this)); }
        }

        #endregion

        #region Methods And Functionss

        /// <summary>
        /// Gestiona la construccion del respositorio genérico asociado al tipo dado.
        /// </summary>
        /// <typeparam name="T">Tipo generalizado que representa la entidad gestionada por el repositorio.</typeparam>
        /// <returns>Instancia de <see cref="IRepository{T}"/> que gestiona el tipo dado.</returns>
        public IRepository<T> CreateRepository<T>() where T : class, new()
        {
            return new EfRepository<T>(this);
        }

        /// <summary>
        /// Gestiona el almacenamiento de los cambios realizados.
        /// </summary>
        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gestiona la correcta liberación de los recursos utilizados por <see cref="EfUnitOfWork"/>.
        /// </summary>
        /// <param name="disposing">True para liberar, false en caso contrario.</param>
        protected virtual void Dispose(bool disposing)
        {
            ////Clean up.
        }

        /// <summary>
        /// Gestiona el almacenamiento de los cambios realizados de manera asincrona.
        /// </summary>
        /// <returns>Succeded si el guardado fue exitoso.</returns>
        public Task SaveChangesAsync()
        {
            return this.Context.SaveChangesAsync();
        }

        #endregion
    }
}