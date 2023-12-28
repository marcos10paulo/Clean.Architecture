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

## Valida��es

- Senha n�o pode ser vazia.
- Senha deve conter ao menos um car�cter especial.
- Senha deve conter ao menos uma letra mai�scula.
- Senha deve conter ao menos uma letra min�scula.
- Senha deve conter ao menos um n�mero.
- Senha deve conter ao menos 8 car�cteres.

