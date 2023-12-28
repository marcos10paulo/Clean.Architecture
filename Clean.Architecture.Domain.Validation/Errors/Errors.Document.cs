using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Domain.Validation.Errors
{
    public static partial class Errors
    {
        public static class Document
        {
            public static Error InvalidValue = Error.Validation(
                code: "Document.InvalidValue",
                description: "Documento inválido!"
            );
            public static Error InvalidLength = Error.Validation(
                code: "Document.InvalidLength",
                description: "Tamanho de CPF ou CNPJ inválido!"
            );
        }
    }
}
