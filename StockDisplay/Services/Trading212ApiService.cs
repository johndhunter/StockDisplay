using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using StockDisplay.Domain;

namespace StockDisplay.Services
{
    public class Trading212ApiService : ITrading212ApiService
    {
        private readonly HttpClient _httpClient;
        private string apiKey = string.Empty;
        private const string UnexpectedError = "Unexpected error";

        public Trading212ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            apiKey = Properties.Settings.Default.ApiKey;
        }

        #region Instruments metadata
        public async Task<List<Exchange>> GetExchangesAsync()
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetExchangesEndpoint);
            var exchanges = new List<Exchange>();

            try
            {
                exchanges = (await _httpClient.GetFromJsonAsync<List<Exchange>>(apiEndpoint))!;
                TraceOutput($"Exchanges:{Environment.NewLine} {JsonSerializer.Serialize(exchanges)}");
            }
            catch (Exception ex)
            {
                HandleException(ex, apiEndpoint, typeof(List<Exchange>));
            }
            return exchanges;
        }

        public async Task<List<Instrument>> GetInstrumentsAsync()
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetInstrumentsEndpoint);
            var instruments = new List<Instrument>();

            try
            {
                instruments = (await _httpClient.GetFromJsonAsync<List<Instrument>>(apiEndpoint))!;
                TraceOutput($"Instruments:{Environment.NewLine}{JsonSerializer.Serialize(instruments)}");
            }
            catch (Exception ex)
            {
                HandleException(ex, apiEndpoint, typeof(List<Instrument>));
            }
            return instruments;
        }
        #endregion instruments metadata

        #region Pies
        public async Task<List<Pie>> GetPiesAsync()
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetPiesEndpoint);
            var pies = new List<Pie>();

            try
            {
                pies = (await _httpClient.GetFromJsonAsync<List<Pie>>(apiEndpoint))!;
                TraceOutput($"Pies:{Environment.NewLine}{JsonSerializer.Serialize(pies)}");
            }
            catch (Exception ex)
            {
                HandleException(ex, apiEndpoint, typeof(List<Pie>));
            }

            return pies;
        }

        public async Task<PieDetail> GetPieAsync(long pieId)
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetPiesEndpoint + $"/{pieId}");
            var pieDetail = new PieDetail();

            try
            {
                pieDetail = (await _httpClient.GetFromJsonAsync<PieDetail>(apiEndpoint))!;
                TraceOutput($"PieDetail:{Environment.NewLine}{JsonSerializer.Serialize(pieDetail)}");
            }
            catch (Exception ex)
            {
                HandleException(ex, apiEndpoint, typeof(PieDetail));
            }
            return pieDetail;
        }

        #endregion Pies

        #region Account Data
        public async Task<AccountCash> GetAccountCashAsync()
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetAccountCashEndPoint);
            var accountCash = new AccountCash();

            try
            {
                accountCash = (await _httpClient.GetFromJsonAsync<AccountCash>(apiEndpoint))!;
                TraceOutput($"AccountCash:{Environment.NewLine}{JsonSerializer.Serialize(accountCash)}");
            }
            catch (Exception ex)
            {
                HandleException(ex, apiEndpoint, typeof(AccountCash));
            }
            return accountCash;
        }

        public async Task<AccountMetadata> GetAccountMetadataAsync()
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetAccountMetaDataEndpoint);
            var accountMetadata = new AccountMetadata();

            try
            {
                accountMetadata = (await _httpClient.GetFromJsonAsync<AccountMetadata>(apiEndpoint))!;
                TraceOutput($"AccountMetadata:{Environment.NewLine}{JsonSerializer.Serialize(accountMetadata)}"); 
            }
            catch (Exception ex)
            {
                HandleException(ex, apiEndpoint, typeof(AccountMetadata));
            }
            return accountMetadata;
        }
        #endregion Account Data

        #region Orders
        public async Task<List<Order>> GetOrdersAsync()
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetEquityOrdersEndpoint);
            var orders = new List<Order>();

            try
            {
                orders = (await _httpClient.GetFromJsonAsync<List<Order>>(apiEndpoint))!;
                TraceOutput($"Orders:{Environment.NewLine}{JsonSerializer.Serialize(orders)}");
            }
            catch (Exception ex)
            {
                HandleException(ex, apiEndpoint, typeof(List<Order>));
            }
            return orders;
        }

        public Task<Order> GetOrderAsync(string orderId)
        {
            throw new NotImplementedException();
        }
        #endregion Orders

        #region Personal Portfolio
        public async Task<List<Position>> GetPositionsAsync()
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetPositionsEndpoint);
            var positions = new List<Position>();
            try
            {
                positions = (await _httpClient.GetFromJsonAsync<List<Position>>(apiEndpoint))!;
                TraceOutput($"Positions:{Environment.NewLine}{JsonSerializer.Serialize(positions)}");
            }
            catch (Exception ex)
            {
                HandleException(ex, apiEndpoint, typeof(List<Position>));
            }
            return positions;

        }

        public async Task<Position> GetPositionAsync(string positionTickerSymbol)
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetPositionsEndpoint + $"/{positionTickerSymbol}");
            var position = new Position();
            try
            {
                position = (await _httpClient.GetFromJsonAsync<Position>(apiEndpoint))!;
                TraceOutput($"Position:{Environment.NewLine}{JsonSerializer.Serialize(position)}");
            }
            catch (Exception ex)
            {
                HandleException(ex, apiEndpoint, typeof(Position));
            }
            return position;
        }

        public async Task<Position> GetPositionByTickerAsync(string tickerSymbol)
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetPositionsByTickerEndpoint);
            var position = new Position();
            try
            { 
                using HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiEndpoint, tickerSymbol);

                response.EnsureSuccessStatusCode();

                position = (await response.Content.ReadFromJsonAsync<Position>())!;
                TraceOutput($"Position:{Environment.NewLine}{JsonSerializer.Serialize(position)}");
            }
            catch (Exception ex)
            {
                HandleException(ex, apiEndpoint, typeof(Position));
            }
            return position;
        }
        #endregion Personal Portfolio

        private void HandleException(Exception ex, string apiEndpoint, Type exceptedType)
        {
            var message = ex switch
            {
                HttpRequestException => "HTTP Error : ",
                JsonException => "JSON Error :",
                _ => UnexpectedError
            };
            TraceOutput($"{message} - calling {apiEndpoint} for type {exceptedType.Name} : {ex.Message}");
        }

        private string GetApiEndpointWithAuthorization(string? target = null)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(apiKey);

            var endpoint = Properties.Settings.Default.UseDevelopmentApi ?
                Properties.Settings.Default.Trading212ApiEndpoint_Dev :
                Properties.Settings.Default.Trading212ApiEndpoint_Prod;

            return endpoint + target;
        }

        private void TraceOutput(string stringToOutput)
        {
            try
            {
                Trace.WriteLine(stringToOutput);
                Trace.WriteLine("");
                Trace.Flush();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred with tracing:{Environment.NewLine}{ex.Message}");
            }
        }
    }
}