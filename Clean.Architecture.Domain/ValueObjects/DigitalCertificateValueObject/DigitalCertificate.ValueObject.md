# Domain ValueObjects

## DigitalCertificate

```csharp
    class DigitalCertificate
    {
        Result<DigitalCertificate> Create();
        // TODO: Add remaining methods
    }
```

```json
{
	"serialNumber": "155615614984", 
	"type": "A1", 
	"name": "Certificate", 
	"issuer": "Test Issuer", 
	"startDate": "2022-11-22T00:00:00.0000000Z", 
	"endDate": "2023-11-22T00:00:00.0000000Z", 
	"file" : "62gsd1a56gh1a5h1516ha51s5ah15"
}
```

## Valida��es

- N�mero Serial (SerialNumber) n�o pode ser vazio.
- Nome (Name) n�o pode ser vazio.
- Emitente (Issuer) n�o pode ser vazio.
- Date de inicial (StartDate) n�o pode ser maior que a Data final (EndDate) do certificado.
- Arquivo (File) n�o pode ser nulo.
