'use strict';

angular.module('tattlrApp')
  .controller('LoginCtrl', function ($scope, AuthService, $modalInstance) {
    AuthService.getAuthProviders().then(function(result) {
      $scope.authProviders = result.data;
      console.log($scope.authProviders);
    }).then(function(){
      AuthService.getUser();
    });

    $scope.ok = function () {
      $modalInstance.close($scope.selected.item);
    };

    $scope.cancel = function () {
      $modalInstance.dismiss('cancel');
    };
  });
