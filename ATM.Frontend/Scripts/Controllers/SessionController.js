function sessionController($scope, $state, AuthorizationService) {

    this.checkSession = function () {
        if (!AuthorizationService.isSession() && $state.current.name != "authentication" && $state.current.name != "authorization") {
            $state.go("authentication");
        } else if (AuthorizationService.getCardNumber() == null && $state.current.name != "authentication") {
            $state.go("authentication");
        }
    }

    this.checkSession();

    $scope.closeSession = function () {
        AuthorizationService.clearSession();
        $state.go("authentication")
    };
}