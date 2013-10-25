function homeCtrl($scope, $location, Parent) {
	$scope.setRoute = function (route) {
		$location.path(route);
	}

	$scope.search = function () {
		$scope.parents = Parent.query();
		console.log(Parent.query());
	}

	$scope.search();

}