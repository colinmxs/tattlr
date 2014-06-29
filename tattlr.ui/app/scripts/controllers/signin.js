'use strict';

angular.module('tattlrApp')
  .controller('SigninCtrl', function ($scope, $location) {
    console.log($location.url());
    console.log($location.path());
  });
