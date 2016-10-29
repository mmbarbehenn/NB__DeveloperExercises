public class ServiceRequest<T>
{
    private string endPoint;
    private object p;

    public ServiceRequest(string endPoint, object p)
    {
        this.endPoint = endPoint;
        this.p = p;
    }

    public object Endpoint { get; internal set; }
    public object Payload { get; internal set; }
}