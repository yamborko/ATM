function cashWithdrawalController($scope, $state, AuthorizationService, CardNumberService) {
    numPadController.call(this, $scope);
    sessionController.call(this, $scope, $state, AuthorizationService);

    $scope.input = 0;

    $scope.addNumber = function(number) {
        $scope.input = $scope.input * 10 + number;
    }

    $scope.withdrawCash = function () {
        var amount = $scope.input;
        if (amount != null && amount > 0) {
            CardNumberService.withdrawCash(AuthorizationService.getSessionValue(), amount).then(function (response) {
                AuthorizationService.setSessionValue(response.SessionValue, true);

                if (response.ErrorCode == 0) {
                    $scope.report = response;
                } else {
                    $state.go("error", { errorCode: response.ErrorCode, errorMessage: response.ErrorMessage, previousPage: "withdraw" })
                }
            }, function (data) {
                $state.go("error", { errorCode: 0, errorMessage: "Невозможно подключиться к серверу", previousPage: "authentication" })
            });
        }
    }
}