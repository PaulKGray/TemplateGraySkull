function headerCtrl($scope) {

	$scope.navMenu = function ($event) {

		var menu = document.getElementById("menuHolder");

		if (menu.style.display == 'block') {
			menu.style.display = 'none';
		}
		else
		{
			menu.style.display = 'block';
		}

		$event.preventDefault();

	};

}