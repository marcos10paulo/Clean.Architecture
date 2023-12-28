using Clean.Architecture.Domain.Validation.ErrorBase;

namespace Clean.Architecture.Domain.Validation.Errors
{
    public static partial class Errors
    {
        public static class Cpf
        {
            public static Error InvalidValue = Error.Validation(
                code: "Cpf.InvalidValue",
                description: "CPF inválido!"
            );
            public static Error CpfLength = Error.Validation(
                code: "Cpf.CpfLength",
                description: "O tamanho do CPF deve ser 11!"
            );
            public static Error CPFSequential = Error.Validation(
                code: "CPF.CPFSequential",
                description: "CPF não pode ser uma sequência de números iguais!"
            );
            public static Error EmptyCPF = Error.Validation(
                code: "CPF.EmptyValue",
                description: "CPF não pode ser vázio!"
            );
        }
    }
}
