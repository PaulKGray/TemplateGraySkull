
//more on directive http://docs.angularjs.org/guide/directive


angular.module('MobileApp.components', [])
	.directive('parentdetails', function () {
		return {

			restrict: 'EA',
			scope: {
				item: '=parentdetails'

			},
			templateUrl: '/partials/parentItem/details.html'

		}

	})

