using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using T212_Updates.Domain;
using T212_Updates.Infrastructure;

namespace T212_Updates.Services
{
    public class Trading212ApiService : ITrading212ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly LogForm _logForm;
        private const string UnexpectedError = "Unexpected error";
        private const int MaxRetries = 5;
        private const int InitialDelayMilliseconds = 2000;

        public Trading212ApiService(HttpClient httpClient, LogForm logForm)
        {
            _httpClient = httpClient;
            _logForm = logForm;
        }

        #region Instruments metadata
        public async Task<Result<List<Exchange>>> GetExchangesAsync()
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetExchangesEndpoint);
            return await ExecuteWithRetryAsync(async () =>
            {
                _logForm.LogInfo($"Fetching Exchange List");
                var exchanges = (await _httpClient.GetFromJsonAsync<List<Exchange>>(apiEndpoint))!;
                LogPretty("Exchanges", exchanges);
                return Result<List<Exchange>>.Success(exchanges);
            }, apiEndpoint, typeof(List<Exchange>));
        }

        public async Task<Result<List<Instrument>>> GetInstrumentsAsync()
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetInstrumentsEndpoint);
            return await ExecuteWithRetryAsync(async () =>
            {
                _logForm.LogInfo($"Fetching Instrument List");
                var instruments = (await _httpClient.GetFromJsonAsync<List<Instrument>>(apiEndpoint))!;
                LogPretty("Instruments", instruments);
                return Result<List<Instrument>>.Success(instruments);
            }, apiEndpoint, typeof(List<Instrument>));
        }
        #endregion instruments metadata

        #region Pies
        public async Task<Result<List<Pie>>> GetPiesAsync()
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetPiesEndpoint);
            return await ExecuteWithRetryAsync(async () =>
            {
                _logForm.LogInfo($"Fetching all pies");
                var pies = (await _httpClient.GetFromJsonAsync<List<Pie>>(apiEndpoint))!;
                LogPretty("Pies", pies);
                return Result<List<Pie>>.Success(pies);
            }, apiEndpoint, typeof(List<Pie>));
        }

        public async Task<Result<PieDetail>> GetPieAsync(long pieId)
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetPiesEndpoint + $"/{pieId}");
            return await ExecuteWithRetryAsync(async () =>
            {
                _logForm.LogInfo($"Fetching a pie with id [{pieId}]");
                var pieDetail = (await _httpClient.GetFromJsonAsync<PieDetail>(apiEndpoint))!;
                LogPretty("PieDetail", pieDetail);
                return Result<PieDetail>.Success(pieDetail);
            }, apiEndpoint, typeof(PieDetail));
        }

        private void LogPretty(string name, object pieDetail)
        {
            _logForm.LogInfo($"{name}:{Environment.NewLine}{JsonSerializer.Serialize(pieDetail, new JsonSerializerOptions { WriteIndented = true })}");
        }
        #endregion Pies

        #region Account Data
        public async Task<Result<AccountCash>> GetAccountCashAsync()
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetAccountCashEndPoint);
            return await ExecuteWithRetryAsync(async () =>
            {
                _logForm.LogInfo($"Fetching account cash");
                var accountCash = (await _httpClient.GetFromJsonAsync<AccountCash>(apiEndpoint))!;
                LogPretty("AccountCash", accountCash);
                return Result<AccountCash>.Success(accountCash);
            }, apiEndpoint, typeof(AccountCash));
        }

        public async Task<Result<AccountMetadata>> GetAccountMetadataAsync()
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetAccountMetaDataEndpoint);
            return await ExecuteWithRetryAsync(async () =>
            {
                _logForm.LogInfo($"Fetching account metadata");
                var accountMetadata = (await _httpClient.GetFromJsonAsync<AccountMetadata>(apiEndpoint))!;
                LogPretty("AccountMetadata", accountMetadata);
                return Result<AccountMetadata>.Success(accountMetadata);
            }, apiEndpoint, typeof(AccountMetadata));
        }
        #endregion Account Data

        #region Orders
        public async Task<Result<List<Order>>> GetOrdersAsync()
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetEquityOrdersEndpoint);
            return await ExecuteWithRetryAsync(async () =>
            {
                _logForm.LogInfo($"Fetching orders");
                var orders = (await _httpClient.GetFromJsonAsync<List<Order>>(apiEndpoint))!;
                LogPretty("Orders", orders);
                return Result<List<Order>>.Success(orders);
            }, apiEndpoint, typeof(List<Order>));
        }

        public async Task<Result<Order>> GetOrderAsync(string orderId)
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetEquityOrdersEndpoint + $"/{orderId}");
                return await ExecuteWithRetryAsync(async () =>
                {
                    _logForm.LogInfo($"Fetching order with id [{orderId}]");
                    var order = (await _httpClient.GetFromJsonAsync<Order>(apiEndpoint))!;
                    LogPretty("Order", order);
                    return Result<Order>.Success(order);
                }, apiEndpoint, typeof(Order));
        }
        #endregion Orders

        #region Personal Portfolio
        public async Task<Result<List<Position>>> GetPositionsAsync()
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetPositionsEndpoint);
            try
            {
                _logForm.LogInfo($"Fetching positions");
                var positions = (await _httpClient.GetFromJsonAsync<List<Position>>(apiEndpoint))!;
                LogPretty("Positions", positions);
                return Result<List<Position>>.Success(positions);
            }
            catch (Exception ex)
            {
                HandleException(ex, apiEndpoint, typeof(List<Position>));
                return Result<List<Position>>.Failure(ex.Message);
            }
        }

        public async Task<Result<Position>> GetPositionAsync(string positionTickerSymbol)
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetPositionsEndpoint + $"/{positionTickerSymbol}");
            try
            {
                _logForm.LogInfo($"Fetching position with ticker [{positionTickerSymbol}]");
                var position = (await _httpClient.GetFromJsonAsync<Position>(apiEndpoint))!;
                LogPretty("Position", position);
                return Result<Position>.Success(position);
            }
            catch (Exception ex)
            {
                HandleException(ex, apiEndpoint, typeof(Position));
                return Result<Position>.Failure(ex.Message);
            }
        }

        public async Task<Result<Position>> GetPositionByTickerAsync(string tickerSymbol)
        {
            string apiEndpoint = GetApiEndpointWithAuthorization(Resources.GetPositionsByTickerEndpoint);
            try
            {
                _logForm.LogInfo($"Searching for a specific position with ticker [{tickerSymbol}]");
                using HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiEndpoint, tickerSymbol);
                response.EnsureSuccessStatusCode();
                var position = (await response.Content.ReadFromJsonAsync<Position>())!;
                LogPretty("Position", position);
                return Result<Position>.Success(position);
            }
            catch (Exception ex)
            {
                HandleException(ex, apiEndpoint, typeof(Position));
                return Result<Position>.Failure(ex.Message);
            }
        }
        #endregion Personal Portfolio

        private string GetApiEndpointWithAuthorization(string? target = null)
        {
            var apiKey = Properties.Settings.Default.ApiKey;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(apiKey);

            var endpoint = Properties.Settings.Default.UseDevelopmentApi ?
                Properties.Settings.Default.Trading212ApiEndpoint_Dev :
                Properties.Settings.Default.Trading212ApiEndpoint_Prod;

            return endpoint + target;
        }

        private async Task<Result<T>> ExecuteWithRetryAsync<T>(Func<Task<Result<T>>> action, string apiEndpoint, Type exceptedType)
        {
            int retryCount = 0;
            int delay = InitialDelayMilliseconds;

            while (true)
            {
                try
                {
                    return await action();
                }
                catch (HttpRequestException ex) when (retryCount < MaxRetries)
                {
                    HandleException(ex, apiEndpoint, exceptedType);
                    await Task.Delay(delay);
                    _logForm.LogWarning($"Retrying {retryCount + 1} of {MaxRetries} after {delay}ms");
                    delay *= 2; // Exponential backoff
                    retryCount++;
                }
                catch (Exception ex)
                {
                    HandleException(ex, apiEndpoint, exceptedType);
                    _logForm.LogError($"Retrying {retryCount + 1} of {MaxRetries} after {delay}ms - timed out");
                    return Result<T>.Failure(ex.Message);
                }
            }
        }
        private void HandleException(Exception ex, string apiEndpoint, Type exceptedType)
        {
            var message = ex switch
            {
                HttpRequestException => "HTTP Error : ",
                JsonException => "JSON Error :",
                _ => UnexpectedError
            };
            _logForm.LogError($"{message} - calling {apiEndpoint} for type {exceptedType.Name} : {ex.Message}");
        }

    }
}