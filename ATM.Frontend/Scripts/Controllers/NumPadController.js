function numPadController($scope) {
    $scope.input = '';

    $scope.addNumber = function (val) {
        $scope.input += val;
    }

    $scope.clear = function (val) {
        $scope.input = "";
    }
}