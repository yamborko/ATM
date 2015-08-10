(function (window, angular, undefined) {
    document.onkeypress = function (e) { event.preventDefault(); };

    var app = angular.module('atm', ['ngResource', 'ui.router']);
    app.service("AuthorizationService", authorizationService);
    app.service("CardNumberService", cardNumberService);
    app.controller("AuthenticationController", authenticationController);
    app.controller("AuthorizationController", authorizationController);
    app.controller("SessionController", sessionController);
    app.controller("CardNumberBalanceController", cardNumberBalanceController);
    app.controller("CashWithdrawalController", cashWithdrawalController);
    app.controller("ErrorsController", errorsController);
    
    app.directive('numpad', function () {
        return {
            restrict: 'E',
            templateUrl: '/Templates/Numpad.html'
        };
    });
    app.directive('sessionControls', function () {
        return {
            restrict: 'E',
            templateUrl: '/authorization/sessioncontrols'
        };
    });

    app.config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("authentication");
        $stateProvider.state('authentication', {
            url: '/authentication',
            views: {
                "": {
                    templateUrl: "Authorization/AuthenticateCardNumber",
                    controller: 'AuthenticationController'
                }
            }
        }).state('authorization', {
            url: '/authorization',
            views: {
                "": {
                    templateUrl: "/Authorization/AuthorizePin",
                    controller: 'AuthorizationController'
                }
            }
        }).state('navigation', {
            url: '/navigation',
            views: {
                "": {
                    templateUrl: "/CardNumber/Navigation",
                    controller: 'SessionController'
                }
            }
        }).state('balance', {
            url: '/balance',
            views: {
                "": {
                    templateUrl: "/CardNumber/CheckCardNumberBalance",
                    controller: 'CardNumberBalanceController'
                }
            }
        }).state('withdraw', {
            url: '/withdraw',
            views: {
                "": {
                    templateUrl: "/CardNumber/WithdrawCash",
                    controller: 'CashWithdrawalController'
                }
            }
        }).state('error', {
            url: '/error',
            params: {
                errorCode: null,
                errorMessage: null,
                previousPage: null
            },
            views: {
                "": {
                    templateUrl: "/base/error",
                    controller: 'ErrorsController'
                }
            }
        });
    });
})(window, angular);