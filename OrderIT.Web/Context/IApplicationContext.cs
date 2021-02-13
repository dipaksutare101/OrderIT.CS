using OrderIT.DomainModel;
using OrderIT.Model;
namespace OrderIT.Web
{
    public interface IApplicationContext
    {
        Repository<Company> Companies { get; }
        Repository<Supplier> Suppliers { get; }
        Repository<Product> Products { get; }
    }
}