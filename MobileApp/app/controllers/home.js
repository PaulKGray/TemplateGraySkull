function homeCtrl($scope, Parent) {

	$scope.search = function () {
		$scope.parents = Parent.query();
	}

	$scope.search();

}