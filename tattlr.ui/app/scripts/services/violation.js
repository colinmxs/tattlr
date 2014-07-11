'use strict';

angular.module('tattlrApp')
  .factory('ViolationService', function ($http) {
    return {
      deleteViolation: function (id) {
        return $http.delete('http://tattlr.azurewebsites.net/api/report/'+id);
      },
      getViolations: function() {
        return $http.get('http://tattlr.azurewebsites.net/api/report/');
      }
    };
  });
