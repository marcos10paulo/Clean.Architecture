# Domain ValueObjects

## Password

```csharp
    class Password
    {
        Result<Password> Create();
        // TODO: Add remaining methods
    }
```

```json
{
	"value": "Test@123"
}
```

## Validações

- Senha não pode ser vazia.
- Senha deve conter ao menos um carácter especial.
- Senha deve conter ao menos uma letra maiúscula.
- Senha deve conter ao menos uma letra minúscula.
- Senha deve conter ao menos um número.
- Senha deve conter ao menos 8 carácteres.

