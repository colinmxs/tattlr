'use strict';

angular.module('tattlrApp')
  .controller('LoginCtrl', function ($scope, AuthService, $modalInstance, $window) {
    AuthService.getAuthProviders().then(function(result) {
      $scope.authProviders = result.data;
      console.log($scope.authProviders);
    }).then(function(){
      AuthService.getUser();
    });

    $scope.goTo = function(provider) {
      $window.location = provider;
    };

    $scope.ok = function () {
      $modalInstance.close($scope.selected.item);
    };

    $scope.cancel = function () {
      $modalInstance.dismiss('cancel');
    };
  });
