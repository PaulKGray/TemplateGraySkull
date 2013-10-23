
//more on directive http://docs.angularjs.org/guide/directive


angular.module('components', [])
	.directive('parentdetails', function () {
		return {

			restrict: 'E',
			scope: {
				parentname: '@parentname'

			},
			templateUrl: '/partials/parentItem/details.html'

		}

	})

