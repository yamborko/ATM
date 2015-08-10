function errorsController($scope, $state, $stateParams) {
    if ($stateParams == null || $stateParams.errorMessage == null) {
        $state.go("authentication");
    }
    $scope.errorMessage = $stateParams.errorMessage;
    $scope.errorCode = $stateParams.errorCode;
    $scope.previousPage = $stateParams.previousPage;
}