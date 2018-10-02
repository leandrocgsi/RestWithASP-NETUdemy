# Rest With ASP.NET Udemy

Este é o repositório dos codigos fonte desenvolvidos no curso [RESTFul API's do 0 à Nuvem Com ASP.NET Core 2.0 e Docker](https://www.udemy.com/restful-apis-do-0-a-nuvem-com-aspnet-core-e-docker/?couponCode=GITHUB)

[![Build Status](https://travis-ci.org/leandrocgsi/RestWithASP-NETUdemy.svg?branch=master)](https://travis-ci.org/leandrocgsi/RestWithASP-NETUdemy)

[Download MySQL](https://dev.mysql.com/downloads/mysql/)

[Download Heidi](https://www.heidisql.com/download.php)

# HTTP Status Codes adotados pelas mais famosas API's do mundo

[Baseado em](https://gist.github.com/vkostyukov/32c84c0c01789425c29a#file-statuses-md)

|API                   | Status Codes                                                                             |
|----------------------|------------------------------------------------------------------------------------------|
|[Twitter][tw]         | 200, 304, 400, 401, 403, 404, 406, 410, 420, 422, 429, 500, 502, 503, 504                |
|[Stripe][stripe]      | 200, 400, 401, 402, 404, 429, 500, 502, 503, 504                                         |
|[Github][gh]          | 200, 400, 422, 301, 302, 304, 307, 401, 403                                              |
|[Pagerduty][pd]       | 200, 201, 204, 400, 401, 403, 404, 408, 500                                              |
|[NewRelic Plugins][nr]| 200, 400, 403, 404, 405, 413, 500, 502, 503, 503                                         |
|[Etsy][etsy]          | 200, 201, 400, 403, 404, 500, 503                                                        |
|[Dropbox][db]         | 200, 400, 401, 403, 404, 405, 429, 503, 507                                              |
|[Spotify][spf]        | 200, 201, 204, 304, 400, 401, 403, 404, 429, 500, 502, 503                               |
|[Google Cloud][gc]    | 200, 301, 304, 307, 308, 400, 401, 403, 404, 405, 409, 411, 412, 416, 429, 500, 501, 503 |
|[HipChat][hc]         | 200, 201, 202, 400, 401, 403, 404, 405, 429, 500, 503                                    |
|[Telegram][tg]        | 200, 303, 400, 401, 403, 404, 420, 500                                                   |
|[Pocket][pk]          | 200, 400, 401, 403, 503                                                                  |
|[Uber][ub]            | 200, 201, 400, 401, 403, 404, 406, 409, 422, 429, 500                                    |


Usado por **todos eles**: 200, 201, 202, 204, 301, 302, 303, 304, 307, 308, 400, 401, 402, 403, 404, 405, 406, 408, 409, 410, 411, 412, 413, 416, 420, 422, 429, 500, 501, 502, 503, 504, 507

Usado por pelo menos **dois deles**: 200, 201, 204, 301, 304, 307, 400, 401, 403, 404, 405, 406, 409, 420, 422, 429, 500, 502, 503, 504

Usado por pelo menos **três deles**: 200, 201, 304, 400, 401, 403, 404, 405, 422, 429, 500, 502, 503

Usado por pelo menos **quatro deles**: 200, 201, 304, 400, 401, 403, 404, 405, 429, 500, 502, 503

Usado por pelo menos **cinco deles**: 200, 201, 400, 401, 403, 404, 405, 429, 500, 503

Usado por pelo menos **todos eles**: 200, 400

[tw]: https://dev.twitter.com/overview/api/response-codes
[stripe]: https://stripe.com/docs/api#errors
[gh]: https://developer.github.com/v3/#client-errors
[pd]: https://developer.pagerduty.com/documentation/rest/errors
[nr]: https://docs.newrelic.com/docs/plugins/plugin-developer-resources/developer-reference/plugin-api-responses-error-codes
[etsy]: https://www.etsy.com/developers/documentation/getting_started/api_basics#section_standard_response_codes
[db]: https://www.dropbox.com/developers-v1/core/docs
[spf]: https://developer.spotify.com/web-api/user-guide/
[gc]: https://cloud.google.com/storage/docs/json_api/v1/status-codes#http-status-and-error-codes
[hc]: https://www.hipchat.com/docs/apiv2/response_codes
[tg]: https://core.telegram.org/api/errors
[pk]: https://getpocket.com/developer/docs/errors
[ub]: https://developer.uber.com/v1/api-reference/

# Exemplos

[Limitando a Quantidade de Requests](https://github.com/stefanprodan/AspNetCoreRateLimit)
