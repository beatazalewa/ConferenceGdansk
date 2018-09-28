using System.ServiceModel;

namespace Services
{
    [ServiceContract]
    public interface IRandomNumberGenerator
    {
        [OperationContract]
        int GetRandomNumber();
    }
}
