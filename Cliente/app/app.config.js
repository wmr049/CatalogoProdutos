'use strict';

app.config(['$locationProvider' ,'$routeProvider',
    function config($locationProvider, $routeProvider) {
        $routeProvider.when("/login", {
            controller: "loginController",
            templateUrl: "/views/login.html"
        });

        $routeProvider.when("/produtos", {
            controller: "produtosController",
            templateUrl: "/views/produtos.html"
        });

        $routeProvider.otherwise({ redirectTo: "/login" });
    }
]);

var serviceBase = 'http://localhost:56357/';

app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
    //authService.skipIfAuthenticated();
}]);