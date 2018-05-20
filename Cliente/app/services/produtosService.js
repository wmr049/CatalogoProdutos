'use strict';
app.factory('produtosService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var produtosServiceFactory = {};

    var _getProdutos = function () {

        return $http.get(serviceBase + 'api/v1/produtos').then(function (results) {
            return results;
        });
    };

    produtosServiceFactory.getProdutos = _getProdutos;

    return produtosServiceFactory;

}]);