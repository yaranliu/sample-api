namespace ApiSampleNoAuth.Schema;

public class FixedPagination
{
    public int CurrentPage { get; set; }
    public int PagesCount { get; set; }
    public int RecordsPerPage { get; set; }
    public int TotalRecords { get; set; }

    public FixedPagination(int currentPage, int pagesCount, int recordsPerPage, int totalRecords)
    {
        CurrentPage = currentPage;
        PagesCount = pagesCount;
        RecordsPerPage = recordsPerPage;
        TotalRecords = totalRecords;
    }
}