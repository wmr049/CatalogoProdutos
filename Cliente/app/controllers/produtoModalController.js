app.controller("produtoModalController", function ($scope) {
    var params = $scope.$resolve.params;
    
    $scope.nome = params.nome;
    $scope.descricao = params.descricao;
    $scope.preco = params.preco;
    
    $scope.cancel = function () {
        $scope.$dismiss();
    };

    $scope.ok = function () {
        var retObj = {
            nome: $scope.nome,
            descricao: $scope.descricao,
            codigo: $scope.codigo,
            preco: $scope.preco
        };
        $scope.$close(retObj);
    };
});
 