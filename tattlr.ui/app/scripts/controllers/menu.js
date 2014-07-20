'use strict';

angular.module('tattlrApp')
  .controller('MenuCtrl', function ($rootScope, $scope, $modal, $location, $http, AuthService) {

    //console.log($rootScope.user);
    // since this controller might be init'd before $rootScope.user has a value
    // we need to watch it for changes.

    $scope.userMenu = {
      isopen: false
    };

    $rootScope.$watch('user',function(){
      console.log($rootScope.user);

      if($rootScope.user) {
        $scope.loggedIn = true;
      } else {
        $scope.loggedIn = false;
      }
    },true);


    $scope.openLoginModal = function() {
      $modal.open({
        templateUrl: 'views/login.html',
        controller: 'LoginCtrl'
      });
    };

    $scope.logOut = function() {
      localStorage.clear();
      $rootScope.user = null;
      AuthService.setAuthHeader('');
      $location.path('/');

    };

  });
