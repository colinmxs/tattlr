'use strict';

angular
  .module('tattlrApp', [
    'ngResource',
    'ngSanitize',
    'ngRoute',
    'ui.bootstrap'
  ])
  .config(function ($routeProvider, $locationProvider, $httpProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'views/main.html',
        controller: 'MainCtrl'
      })
      .when('/about', {
        templateUrl: 'views/about.html',
        controller: 'AboutCtrl'
      })
      .when('/signin', {
        templateUrl: 'views/signin.html',
        controller: 'SigninCtrl'
      });
      // .otherwise({
      //   redirectTo: '/'
      // });

    $locationProvider.html5Mode(true);

    $httpProvider.interceptors.push('responseCheck');

  })

  .run(function($rootScope, $http) {
    // Here we check to see if a user exists in localStorage and set the default
    // headers with a valid access token.
    var user = JSON.parse(localStorage.getItem('user'));

    if(user) {
      $rootScope.user = user;

      $http.defaults.headers.common.Authorization = 'Bearer ' + user.accessToken;
    } else {
      console.log('user not found.');
      $rootScope.user = null;
    }

  })

  .factory('responseCheck', function ($q) {
    return {
        response: function (response) {
            // do something on success
            console.log(response.status);
            return response;
          },
        responseError: function (response) {
            // do something on error
            console.log(response.status);
            if(response.status === 401) {
              console.log('Login required.');
            }

            return $q.reject(response);
          }
      };
  });
