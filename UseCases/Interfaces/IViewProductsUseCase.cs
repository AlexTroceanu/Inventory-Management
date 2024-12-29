using CoreBusiness;

namespace UseCases
{
    public interface IViewProductsUseCase
    {
        IEnumerable<Product> Execute(bool loadCategory = false);
    }
}