namespace ApiSampleNoAuth.Schema;

public class ContinuousPagination
{
    public string IdentifierField { get; set; }
    public bool After { get; set; }
    public ContinuousPagination(string identifierField, bool after)
    {
        IdentifierField = identifierField;
        After = after;
    }
}