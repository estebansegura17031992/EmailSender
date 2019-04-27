angular.module("EmailSender")
    .config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        }).hashPrefix('!'); 
        $routeProvider
            .when('/', {
                templateUrl: '/AngularTemplates/Home.html',
                controller: 'HomeController'
            })
            .when("/Home/Historial", {
                templateUrl: '/AngularTemplates/Historial.html',
                controller: 'HistorialController'
            })
            .otherwise({ redirectTo: '/' });
    }])