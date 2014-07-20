'use strict';

angular.module('tattlrApp')
  .controller('AboutCtrl', function ($scope, ViolationService) {

    $scope.loadingViolations = ViolationService.getViolations().then(function(response) {
      $scope.violations = response.data;

    });

    $scope.viewViolation = function (violation) {

      //ViolationDetailService.setViolation(violation);
      //$location.path('violationDetail');

    };

  });
