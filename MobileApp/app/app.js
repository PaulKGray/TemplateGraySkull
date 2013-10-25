

var myApp = angular.module('MobileApp', ['components', 'ParentService'])
	.config(function ($routeProvider) {

		$routeProvider.
			when('/about', { templateUrl: '/partials/about.html' }).
			when('/contact', { templateUrl: '/partials/contact.html' }).
			when('/login', { templateUrl: '/partials/login.html' }).
			otherwise({ redirectTo: '/home', templateUrl: '/partials/home.html' });
	});

function mainCtrl($scope, $location) {
	$scope.setRoute = function (route) {
		$location.path(route);
	}



}