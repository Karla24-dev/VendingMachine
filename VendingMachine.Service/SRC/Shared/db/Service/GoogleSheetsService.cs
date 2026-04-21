namespace VendingMachine.Service.Shared.db.Service;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Services;
using Google.Apis.Sheets.v4.Data;
using System.Text;

public class GoogleSheetsService
{
    private readonly SheetsService _sheetsService;
    private readonly string _spreadsheetId;

    public GoogleSheetsService(IConfiguration configuration)
    {
        // ========================================
        // CONSTRUIR EL JSON DE CREDENCIALES
        // ========================================
        
        var credentialsJson = $@"{{
            ""type"": ""{configuration["GoogleSheets:type"]}"",
            ""project_id"": ""{configuration["GoogleSheets:project_id"]}"",
            ""private_key_id"": ""{configuration["GoogleSheets:private_key_id"]}"",
            ""private_key"": ""{configuration["GoogleSheets:private_key"]}"",
            ""client_email"": ""{configuration["GoogleSheets:client_email"]}"",
            ""client_id"": ""{configuration["GoogleSheets:client_id"]}"",
            ""auth_uri"": ""{configuration["GoogleSheets:auth_uri"]}"",
            ""token_uri"": ""{configuration["GoogleSheets:token_uri"]}"",
            ""auth_provider_x509_cert_url"": ""{configuration["GoogleSheets:auth_provider_x509_cert_url"]}"",
            ""client_x509_cert_url"": ""{configuration["GoogleSheets:client_x509_cert_url"]}"",
            ""universe_domain"": ""{configuration["GoogleSheets:universe_domain"]}""
        }}";

        // ========================================
        // MÉTODO NUEVO Y SEGURO (sin FromJson obsoleto)
        // ========================================
        
        // Convertir el string JSON a un stream (flujo de bytes)
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(credentialsJson));
        
        // Crear credencial usando el método recomendado
        var credential = ServiceAccountCredential.FromServiceAccountData(stream);
        
        // Crear credencial de Google con los scopes necesarios
        var googleCredential = GoogleCredential.FromServiceAccountCredential(credential)
            .CreateScoped(SheetsService.Scope.Spreadsheets);

        // Crear servicio de Google Sheets
        _sheetsService = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = googleCredential,
            ApplicationName = "VendingMachine"
        });

        // Obtener Spreadsheet ID
        _spreadsheetId = configuration["GoogleSheets:SpreadsheetId"]
            ?? throw new Exception("GoogleSheets:SpreadsheetId not found in User Secrets");
    }

    public async Task<IList<IList<object>>?> ReadSheetAsync(string sheetName, string range)
    {
        var request = _sheetsService.Spreadsheets.Values.Get(
            _spreadsheetId, 
            $"{sheetName}!{range}"
        );
        
        var response = await request.ExecuteAsync();
        return response.Values;
    }

    public async Task AppendSheetAsync(string sheetName, IList<IList<object>> values)
    {
        var valueRange = new ValueRange 
        { 
            Values = values 
        };

        var request = _sheetsService.Spreadsheets.Values.Append(
            valueRange,
            _spreadsheetId,
            $"{sheetName}!A:Z"
        );

        request.ValueInputOption = SpreadsheetsResource.ValuesResource
            .AppendRequest.ValueInputOptionEnum.USERENTERED;

        await request.ExecuteAsync();
    }

    public async Task UpdateSheetAsync(string sheetName, string range, IList<IList<object>> values)
    {
        var valueRange = new ValueRange 
        { 
            Values = values 
        };

        var request = _sheetsService.Spreadsheets.Values.Update(
            valueRange,
            _spreadsheetId,
            $"{sheetName}!{range}"
        );

        request.ValueInputOption = SpreadsheetsResource.ValuesResource
            .UpdateRequest.ValueInputOptionEnum.USERENTERED;

        await request.ExecuteAsync();
    }

    public async Task ClearSheetAsync(string sheetName, string range)
    {
        var request = _sheetsService.Spreadsheets.Values.Clear(
            new ClearValuesRequest(),
            _spreadsheetId,
            $"{sheetName}!{range}"
        );

        await request.ExecuteAsync();
    }
}

