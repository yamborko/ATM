function cardNumberBalanceController($scope, $state, AuthorizationService, CardNumberService) {
    sessionController.call(this, $scope, $state, AuthorizationService);
    $scope.response = {};
    CardNumberService.checkAccountBalance(AuthorizationService.getSessionValue()).then(function (response) {
        AuthorizationService.setSessionValue(response.SessionValue, true);

        if (response.ErrorCode == 0) {
            $scope.response = response;
        } else {
            $state.go("error", { errorCode: response.ErrorCode, errorMessage: response.ErrorMessage, previousPage: "navigation" });
        }
    }, function (data) {
        $state.go("error", { errorCode: 0, errorMessage: "Connection problems", previousPage: "authentication" })
    });;

}