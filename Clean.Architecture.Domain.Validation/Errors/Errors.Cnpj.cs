using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Domain.Validation.Errors
{
    public static partial class Errors
    {
        public static class Cnpj
        {
            public static Error CnpjLength = Error.Validation(
                code: "Cnpj.CnpjLength",
                description: "CNPJ deve ter o tamanho de 14!"
            );

            public static Error EmptyCnpj = Error.Validation(
                code: "Cnpj.EmptyCnpj",
                description: "CNPJ não pode ser vázio!"
            );

            public static Error CnpjSequential = Error.Validation(
                code: "Cnpj.CnpjSequential",
                description: "Cnpj não pode ser uma sequência de números iguais!"
            );

            public static Error InvalidValue = Error.Validation(
                code: "Cnpj.InvalidValue",
                description: "CNPJ inválido!"
            );
        }
    }
}
