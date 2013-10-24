angular.module("ParentService", ["ngResource"]).
       factory("Parent", function ($resource) {
       	return $resource(
						"/api/ParentAPI/:Id",
						{ Id: "@Id" },
						{ "update": { method: "PUT" } }
			 );
       });

//http://odetocode.com/blogs/scott/archive/2013/02/28/mapping-an-angular-resource-service-to-a-web-api.aspx