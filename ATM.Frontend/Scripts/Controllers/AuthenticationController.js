function authenticationController($scope, $state, AuthorizationService) {
    numPadController.call(this, $scope);
    sessionController.call(this, $scope, $state, AuthorizationService);

    $scope.input = "1111-2222-3333-4444";
    $scope.addNumber = function (number) {
        $scope.input = inputReform($scope.input + number, 4, '-', 3, 16);
    }

    $scope.authenticateCardNumber = function () {
        AuthorizationService.clearSession();

        var cardNumber = $scope.input.replace(/[-]/g, '');
        if (cardNumber.length == 16) {
            AuthorizationService.authenticateCardNumber(cardNumber).then(function (response) {
                    if (response.ErrorCode == 0) {
                        AuthorizationService.setCardNumber(cardNumber, true);

                        $state.go("authorization")
                    } else {
                        $state.go("error", { errorCode: response.ErrorCode, errorMessage: response.ErrorMessage, previousPage: "authentication" })
                    }
                }, function (data) {
                    $state.go("error", { errorCode: 0, errorMessage: "Невозможно подключиться к серверу", previousPage: "authentication" })
                });
        }
    }

    function inputReform(val, step, delimiter, num, length) {
        val = val.split(delimiter);
        val = val.join("");

        var new_num = 0;
        var new_val = "";
        for (var i = 0; i < val.length; i++) {
            if (new_val.length < length + num) {

                if ((i) % step == 0 && i != 0 && new_num < num) {
                    new_val += delimiter;
                    new_num++;
                }

                new_val += val[i];
            }
        }

        return new_val;
    }
}