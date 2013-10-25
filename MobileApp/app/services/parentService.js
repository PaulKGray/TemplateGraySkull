angular.module('MobileApp.ParentService', ['ngResource']).
      factory('Parent', function ($resource) {
      	return $resource("http://localhost:55539\:55539/api/ParentAPI");

      });
