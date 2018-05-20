'use strict';
app.factory('authService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', '$location',
    function ($http, $q, localStorageService, ngAuthSettings, $location) {
        var serviceBase = ngAuthSettings.apiServiceBaseUri;
        var authServiceFactory = {};

        var _authentication = {
            isAuth: false,
            userName: "",
            expirationToken: "",
            useRefreshTokens: false
        };        

        var _saveRegistration = function (registration) {

            _logOut();

            return $http.post(serviceBase + 'api/v1/nova-conta', registration).then(function (response) {
                return response;
            });

        };

        var _login = function (loginData) {
            
            var deferred = $q.defer();
            $http.post(
                serviceBase + 'api/v1/conta', 
                loginData, 
                { headers: { 'Content-Type': 'application/json' } }
            ).success(function (response) {

                if (loginData.useRefreshTokens) {
                    localStorageService.set('authorizationData', {
                        token: response.data.result.access_token,
                        userName: loginData.email,
                        refreshToken: response.data.result.expires_in,
                        user: response.data.result.user,
                        useRefreshTokens: true
                    });
                }
                else {
                    localStorageService.set('authorizationData', {
                        token: response.data.result.access_token,
                        userName: loginData.email,
                        refreshToken: response.data.result.expires_in,
                        user: response.data.result.user,
                        useRefreshTokens: false
                    });
                }
                _authentication.isAuth = true;
                _authentication.userName = loginData.email;
                _authentication.expirationToken = response.data.result.user.expires;
                _authentication.useRefreshTokens = loginData.rememberMe;

                deferred.resolve(response);

            }).error(function (err, status) {
                _logOut();
                deferred.reject(err);
            });

            return deferred.promise;

        };

        var _logOut = function () {

            localStorageService.remove('authorizationData');

            _authentication.isAuth = false;
            _authentication.userName = "";
            _authentication.useRefreshTokens = false;

        };       

        var _fillAuthData = function () {

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                _authentication.isAuth = true;
                _authentication.userName = authData.userName;
                _authentication.useRefreshTokens = authData.useRefreshTokens;
            }

        };
                        
        authServiceFactory.saveRegistration = _saveRegistration;
        authServiceFactory.login = _login;
        authServiceFactory.logOut = _logOut;
        authServiceFactory.fillAuthData = _fillAuthData;
        authServiceFactory.authentication = _authentication;                                

        return authServiceFactory;
}]);