namespace Library.Domain.Exceptions
{
    public class DuplicateEntityException : ValidationException
    {
        public string EntityName { get; }
        public string DuplicateField { get; }
        public string DuplicateValue { get; }

        public DuplicateEntityException(string entityName, string field, string value)
            : base($"{entityName} con {field} '{value}' ya existe.")
        {
            EntityName = entityName;
            DuplicateField = field;
            DuplicateValue = value;
        }
    }
}
