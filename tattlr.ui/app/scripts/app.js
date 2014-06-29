'use strict';

angular
  .module('tattlrApp', [
    'ngResource',
    'ngSanitize',
    'ngRoute',
    'ui.bootstrap'
  ])
  .config(function ($routeProvider, $locationProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'views/main.html',
        controller: 'MainCtrl'
      })
      .when('/about', {
        templateUrl: 'views/about.html',
        controller: 'AboutCtrl'
      })
      .when('/signin-facebook', {
        templateUrl: 'views/signin.html',
        controller: 'SigninCtrl'
      })
      .when('/signin-twitter', {
        templateUrl: 'views/signin.html',
        controller: 'SigninCtrl'
      });
      // .otherwise({
      //   redirectTo: '/'
      // });

    $locationProvider.html5Mode(true);
  });
