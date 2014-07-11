'use strict';

angular.module('tattlrApp')
  .controller('MenuCtrl', function ($rootScope, $scope, $modal) {

    console.log($rootScope.user);
    if($rootScope.user) {
      $scope.loggedIn = true;
    } else {
      $scope.loggedIn = false;
    }


    $scope.openLoginModal = function() {
      $modal.open({
        templateUrl: 'views/login.html',
        controller: 'LoginCtrl'
      });
    };
  });
