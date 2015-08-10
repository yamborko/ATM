(function (window, angular, undefined) {
    document.onkeypress = function (e) { event.preventDefault(); };

    var app = angular.module('atm', ['ngResource', 'ui.router']);
    app.service("AuthorizationService", ['$resource', authorizationService]);
    app.service("CardNumberService", ['$resource', cardNumberService]);
    app.controller("AuthenticationController", ['$scope', '$state', 'AuthorizationService', authenticationController]);
    app.controller("AuthorizationController", ['$scope', '$state', 'AuthorizationService', authorizationController]);
    app.controller("SessionController", ['$scope', '$state', 'AuthorizationService', sessionController]);
    app.controller("CardNumberBalanceController", ['$scope', '$state', 'AuthorizationService', 'CardNumberService', cardNumberBalanceController]);
    app.controller("CashWithdrawalController", ['$scope', '$state', 'AuthorizationService', 'CardNumberService', cashWithdrawalController]);
    app.controller("ErrorsController", ['$scope', '$state', '$stateParams', errorsController]);
    
    app.directive('numpad', function () {
        return {
            restrict: 'E',
            templateUrl: '/Templates/Numpad.html'
        };
    });
    app.directive('sessionControls', function () {
        return {
            restrict: 'E',
            templateUrl: '/authorization/sessioncontrols',
            link: function (scope, element, attributes) {
                scope.back = attributes["back"];
                scope.exit = JSON.parse(attributes["exit"]);
            }
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