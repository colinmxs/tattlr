'use strict';

angular.module('tattlrApp')
  .factory('ViolationDetailService', function () {

    var violation = null;

    // Public API here
    return {
      getViolation: function () {
        return this.violation;
      },
      setViolation: function (v) {
        this.violation = v;
      }
    };
  });
