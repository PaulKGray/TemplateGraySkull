function homeCtrl($scope, Parent, $location) {

	$scope.search = function () {
		$scope.parents = Parent.query();
	}

	$scope.search();

	$scope.OpenItem = function (parentId) {

		alert("this is opening" + parentId);


	}


}