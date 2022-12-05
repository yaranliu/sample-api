namespace ApiSampleNoAuth.Schema;

public class ResponseSchema<T>
{
    public T Payload { get; set; }

    public ResponseSchema(T payload)
    {
        Payload = payload;
    }
}