'use strict';

app.config(['$locationProvider' ,'$routeProvider',
    function config($locationProvider, $routeProvider) {
        $routeProvider.when("/login", {
            controller: "loginController",
            templateUrl: "/views/login.html"
        });

        $routeProvider.otherwise({ redirectTo: "/login" });
    }
]);

var serviceBase = 'http://localhost:56357/';

app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});