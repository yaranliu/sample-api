namespace ApiSampleNoAuth.Schema;

public class ContinuousPaginationResponseSchema<T>
{
    public T Payload { get; set; }
    public ContinuousPagination Pagination { get; set; }

    public ContinuousPaginationResponseSchema(T payload, string identifierField, bool after)
    {
        Payload = payload;
        Pagination = new ContinuousPagination(identifierField, after);
    }
}