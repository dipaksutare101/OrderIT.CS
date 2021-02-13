using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using OrderIT.Model;
using OrderIT.DomainModel;

namespace OrderIT.Web
{
    public sealed class ApplicationContext : IApplicationContext
    {
        private static object _sync = new object();
        private static volatile ApplicationContext _currentInstance;
        
        private readonly IUnityContainer _container;
        private readonly UnityConfigurationSection _configurationSection;

        private ApplicationContext()
        {
            _container = new UnityContainer();
            _configurationSection = Configuration.UnitySection as UnityConfigurationSection;
            if (_configurationSection.Containers.Default != null)
                _configurationSection.Configure(_container);
        }

        public static ApplicationContext Current
        {
            get
            {
                if (_currentInstance == null)
                {
                    lock (_sync)
                    {
                        if (_currentInstance == null)
                            _currentInstance = new ApplicationContext();
                    }
                }
                return _currentInstance;
            }
        }

        public IUnityContainer Container
        {
            get { return _container; }
        }

        public Repository<Company> Companies
        {
            get { return Container.Resolve<Repository<Company>>(); }
        }

        public Repository<Supplier> Suppliers
        {
            get { return Container.Resolve<Repository<Supplier>>(); }
        }

        public Repository<Product> Products
        {
            get { return Container.Resolve<Repository<Product>>(); }
        }

    }
}
