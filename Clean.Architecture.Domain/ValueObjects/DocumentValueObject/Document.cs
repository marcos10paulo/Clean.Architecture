using Clean.Architecture.Domain.ValueObjects.CnpjValueObject;
using Clean.Architecture.Domain.ValueObjects.CpfValueObject;
using Clean.Architecture.Domain.ValueObjects.DocumentValueObject.Enums;
using Clean.Architecture.Domain.Validation.ErrorBase;
using Clean.Architecture.Domain.Validation.Errors;
using Clean.Architecture.Domain.Validation.ValidationBase;

namespace Clean.Architecture.Domain.ValueObjects.DocumentValueObject
{
    public class Document : IValidable<Document>
    {
        public string Value { get; private set; }
        public DocumentType DocumentType { get; private set; }
        public Document(string value)
        {
            Value = value;
        }

        public static Result<Document> Create(string value)
        {
            Document document = new (value);

            return ValidateDocument(document);
        }

        public Result<Document> Validate(Document value)
        {
            return ValidateDocument(value);
        }

        public static string AddMask(string document)
        {
            if (document.Length is 11)
                return Cpf.AddMask(document);

            return Cnpj.AddMask(document);
        }

        public static string RemoveMask(string document, DocumentType documentType)
        {
            if (documentType == DocumentType.Cpf)
                return Cpf.RemoveMask(document);
            return Cnpj.RemoveMask(document);
        }

        private static Result<Document> ValidateDocument(Document document)
        {
            if (document.Value.Length is 11)
            {
                var cpf = Cpf.Create(document.Value);
                if (cpf.IsFailure) return Result<Document>.Fail(cpf.Error);

                document.DocumentType = DocumentType.Cpf;

                return Result<Document>.Ok(document);
            }

            else if (document.Value.Length is 14)
            {
                var cnpj = Cnpj.Create(document.Value);
                if (cnpj.IsFailure) return Result<Document>.Fail(cnpj.Error);

                document.DocumentType = DocumentType.Cnpj;

                return Result<Document>.Ok(document);
            }

            return Result<Document>.Fail(Errors.Document.InvalidLength);
        }
    }
}
