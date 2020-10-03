// create the module and name it SMSApp    
var SMSApp = angular.module('SMSApp', ['ngRoute']);

// configure our routes    
SMSApp.config(function ($routeProvider) {
    $routeProvider
    // route for the home page    
        .when('/Login', {
            templateUrl: 'Account/Login',
            controller: 'AccountController'
        })
});

// create the controller and inject Angular's $scope    
SMSApp.controller('AccountController', function ($scope) {
    // create a message to display in our view    
    $scope.Message = 'Account Controller Called !!!';
});



