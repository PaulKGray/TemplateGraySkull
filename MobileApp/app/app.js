

var myApp = angular.module('MobileApp', [
	'MobileApp.components',
	'MobileApp.ParentService'])
	.config(function ($routeProvider) {

		$routeProvider.
			when('/about', { templateUrl: '/partials/about.html' }).
			when('/contact', { templateUrl: '/partials/contact.html' }).
			when('/login', { templateUrl: '/partials/login.html', controller: 'loginCtrl' }).
			otherwise({ redirectTo: '/home', templateUrl: '/partials/home.html', controller: 'homeCtrl' });
	});



