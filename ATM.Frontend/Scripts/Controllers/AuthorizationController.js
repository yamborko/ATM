function authorizationController($scope, $state, AuthorizationService) {
    numPadController.call(this, $scope);
    sessionController.call(this, $scope, $state, AuthorizationService);

    $scope.input = "1234";

    var pin = "1234";

    $scope.addNumber = function (number) {
        if (pin.length < 4) {
            pin += number;
            $scope.input += '*';
        }
    }

    $scope.clear = function () {
        pin = "";
        $scope.input = "";
    }

    $scope.authorizePin = function () {
        if (pin.length == 4) {
            AuthorizationService.authorizePin(pin).then(function (response) {
                AuthorizationService.setSessionValue(response.SessionValue, true);

                if (response.ErrorCode == 0) {
                    $state.go("navigation")
                } else {
                    $state.go("error", { errorCode: response.ErrorCode, errorMessage: response.ErrorMessage, previousPage: "authorization" });
                }
            }, function (data) {
                $state.go("error", { errorCode: 0, errorMessage: "Невозможно подключиться к серверу", previousPage: "authentication" })
            });
        }
    }
}