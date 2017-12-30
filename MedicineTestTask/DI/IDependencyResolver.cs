namespace MedicineTestTask.DI
{
    public interface IDependencyResolver
    {
        void Register<TInterface, TImplemenation>() where TImplemenation: TInterface;
        void RegisterAsSingltone<TInterface, TImplemenation>() where TImplemenation : TInterface;
        TInterface Resolve<TInterface>();
    }
}
