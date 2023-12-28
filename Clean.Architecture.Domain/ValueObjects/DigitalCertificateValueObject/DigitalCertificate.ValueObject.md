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

## Validações

- Número Serial (SerialNumber) não pode ser vazio.
- Nome (Name) não pode ser vazio.
- Emitente (Issuer) não pode ser vazio.
- Date de inicial (StartDate) não pode ser maior que a Data final (EndDate) do certificado.
- Arquivo (File) não pode ser nulo.
