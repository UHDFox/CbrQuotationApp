# CbrQuotationApp
Тестовое задание для компании "SystemGlobalServices"
CbrQuotationApp — это веб-сервис на ASP.NET Core, который предоставляет информацию о курсах валют ЦБ РФ. Имеется возможность получения курса конкретной валюты по ее коду и получения списка валют с пагинацией.
В приложении реализовано кэширование значений в связи с редкой частотой обновления значений ЦБ РФ(раз в сутки).

## Описание

Приложение получает данные о курсах валют с официального API ЦБ РФ (https://www.cbr-xml-daily.ru/daily_json.js) и предоставляет два API метода:

GET /currencies — Возвращает список курсов валют с возможностью пагинации.

GET /currency/ — Возвращает курс валюты по её коду.

## Требования

.NET 7.0+

ASP.NET Core


## Установка и запуск

1. Клонирование репозитория

```bash
git clone https://github.com/UHDFox/CbrQuotationApp.git
cd CbrQuotationApp
```

2. Запуск через .NET CLI
```bash
dotnet build

dotnet run --project CbrQuotationApp
```
## Конфигурация

Настройки API находятся в файле appsettings.json:
```json
{
  "CurrencyApiSettings": {
    "BaseUrl": "https://www.cbr-xml-daily.ru/daily_json.js"
  }
}
```
### API Методы

#### GET /currencies

Описание: Возвращает список курсов валют с пагинацией.

Пример запроса:

``` GET http://localhost:5000/api/v1/currencies?offset=0&limit=10```

Ответ:

```json
[
  {
    "id": "USD",
    "numCode": "840",
    "charCode": "USD",
    "nominal": 1,
    "name": "Доллар США",
    "value": 74.50,
    "previous": 74.20
  }
]
```
#### GET /currency/

Описание: Возвращает курс конкретной валюты по её коду.

Пример запроса:

```GET https://localhost:5000/api/v1/Currency/GetByCode?code=AZN```

Ответ:
```json
{
  "id": "USD",
  "numCode": "840",
  "charCode": "USD",
  "nominal": 1,
  "name": "Доллар США",
  "value": 74.50,
  "previous": 74.20
}
```
## Кэширование

Для оптимизации API реализовано кэширование с использованием IMemoryCache
