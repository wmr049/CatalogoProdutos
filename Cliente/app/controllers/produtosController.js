'use strict';
app.controller('produtosController', ['$scope', 'produtosService', function ($scope, produtosService) {

    $scope.produtos = [];

    produtosService.getProdutos().then(function (results) {

        $scope.produtos = results.data;

    }, function (error) {
        alert(error.data.message);
    });

}]);