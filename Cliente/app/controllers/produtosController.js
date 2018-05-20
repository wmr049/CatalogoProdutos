'use strict';
app.controller('produtosController', ['$scope', 'produtosService',"$uibModal",
    function ($scope, produtosService, $uibModal) 
    {
        $scope.produtos = [];
        $scope.result = null;

        $scope.openDialog = function () {
            var modalInstance = $uibModal.open({
               templateUrl: "views/produtosModal.html",
               controller: "produtoModalController",               
               resolve: {
                  params: function () {
                     return {
                        nome: "",
                        descricao: "",
                        codigo: null,
                        preco: null
                     };
                  }
               }
            });
            
            modalInstance.result.then(function (result) {                
                produtosService.postProdutos(result).then(function (results) {
                    $scope.produtos.push(results.data.data);
                }, function (error) {
                    alert(error.data.message);
                });

               }, function () {
                  console.log("fechado dialogo");
               });
         };
        
         $scope.searchProdutos = function (){
            produtosService.getProdutos().then(function (results) {
                $scope.produtos = results.data;
    
            }, function (error) {
                alert(error.data.message);
            });
         };
    }
]);