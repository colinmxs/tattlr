'use strict';

angular.module('tattlrApp')
  .controller('MenuCtrl', function ($scope, $modal) {
    $scope.openLoginModal = function() {
      $modal.open({
        templateUrl: 'views/login.html',
        controller: 'LoginCtrl'
      });
    };
  });
