namespace ApiSampleNoAuth.Schema;

public class FixedPaginationResponseSchema<T>
{
    public T Payload { get; set; }
    public FixedPagination Pagination { get; set; }

    public FixedPaginationResponseSchema(T payload, int currentPage, int pagesCount, int recordsPerPage, int totalRecords)
    {
        Payload = payload;
        Pagination = new FixedPagination(currentPage, pagesCount, recordsPerPage, totalRecords);
    }
}
