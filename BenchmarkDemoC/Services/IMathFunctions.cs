using System.ServiceModel;


namespace Services
{
    [ServiceContract]
    public interface IMathFunctions
    {
        [OperationContract]
        int Square();
    }
}
